using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Areas.Admin.Controllers
{
    [Area("admin")]
    //[Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Kullanıcıları listele
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userList = new List<UserListViewModel>();

            foreach (var user in users)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                userList.Add(new UserListViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    Roles = userRoles.ToList()
                });
            }

            ViewBag.TotalUsers = users.Count;
            ViewBag.ConfirmedUsers = users.Count(u => u.EmailConfirmed);
            ViewBag.AdminCount = userList.Count(u => u.Roles.Any(r => string.Equals(r, "admin", StringComparison.OrdinalIgnoreCase)));

            return View(userList);
        }

        // Kullanıcı rollerini yönet (GET)
        [HttpGet]
        public async Task<IActionResult> ManageRoles(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                TempData["Error"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            var allRoles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new ManageUserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                UserRoles = allRoles.Select(role => new RoleSelectionViewModel
                {
                    RoleName = role.Name,
                    IsSelected = userRoles.Contains(role.Name)
                }).ToList()
            };

            return View(model);
        }

        // Kullanıcı rollerini yönet (POST)
        [HttpPost]
        public async Task<IActionResult> ManageRoles(ManageUserRolesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            if (currentRoles.Any())
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                {
                    TempData["Error"] = "Roller kaldırılırken hata oluştu.";
                    return View(model);
                }
            }

            var selectedRoles = model.UserRoles
                .Where(r => r.IsSelected)
                .Select(r => r.RoleName)
                .ToList();

            if (selectedRoles.Any())
            {
                var addResult = await _userManager.AddToRolesAsync(user, selectedRoles);
                if (!addResult.Succeeded)
                {
                    TempData["Error"] = "Roller eklenirken hata oluştu.";
                    return View(model);
                }
            }

            TempData["Success"] = $"{user.UserName} kullanıcısının rolleri başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        // Yeni rol oluştur (GET)
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        // Yeni rol oluştur (POST)
        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                TempData["Error"] = "Rol adı boş olamaz.";
                return View();
            }

            if (await _roleManager.RoleExistsAsync(roleName))
            {
                TempData["Error"] = "Bu rol zaten mevcut.";
                return View();
            }

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (result.Succeeded)
            {
                TempData["Success"] = $"'{roleName}' rolü başarıyla oluşturuldu.";
                return RedirectToAction("RoleList");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }

        // Rolleri listele
        public async Task<IActionResult> RoleList()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var roleViewModels = new List<RoleViewModel>();

            foreach (var role in roles)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
                roleViewModels.Add(new RoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    UserCount = usersInRole.Count
                });
            }

            return View(roleViewModels);
        }

        // Rol sil
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                TempData["Error"] = "Rol bulunamadı.";
                return RedirectToAction("RoleList");
            }

            if (string.Equals(role.Name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                TempData["Error"] = "Admin rolü silinemez.";
                return RedirectToAction("RoleList");
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["Success"] = $"'{role.Name}' rolü başarıyla silindi.";
            }
            else
            {
                TempData["Error"] = "Rol silinirken hata oluştu.";
            }

            return RedirectToAction("RoleList");
        }

        // Kullanıcı detayları
        public async Task<IActionResult> UserDetails(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var model = new UserDetailsViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnabled = user.TwoFactorEnabled,
                LockoutEnabled = user.LockoutEnabled,
                LockoutEnd = user.LockoutEnd,
                AccessFailedCount = user.AccessFailedCount,
                Roles = roles.ToList()
            };

            return View(model);
        }

        // Kullanıcıyı kilitle/kilidini aç
        [HttpPost]
        public async Task<IActionResult> ToggleLockout(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            if (user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.Now)
            {
                await _userManager.SetLockoutEndDateAsync(user, null);
                TempData["Success"] = $"{user.UserName} kullanıcısının kilidi açıldı.";
            }
            else
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Now.AddDays(30));
                TempData["Success"] = $"{user.UserName} kullanıcısı 30 gün süreyle kilitlendi.";
            }

            return RedirectToAction("Index");
        }

        // Email onaylama (admin tarafından manuel)
        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            user.EmailConfirmed = true;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["Success"] = $"{user.Email} adresi onaylandı.";
            }
            else
            {
                TempData["Error"] = "Email onaylama işlemi başarısız.";
            }

            return RedirectToAction("Index");
        }

        // Kullanıcı sil
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["Error"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null && currentUser.Id == user.Id)
            {
                TempData["Error"] = "Kendi hesabınızı silemezsiniz.";
                return RedirectToAction("Index");
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["Success"] = $"{user.UserName} kullanıcısı başarıyla silindi.";
            }
            else
            {
                TempData["Error"] = "Kullanıcı silinirken hata oluştu.";
            }

            return RedirectToAction("Index");
        }
    }
}
