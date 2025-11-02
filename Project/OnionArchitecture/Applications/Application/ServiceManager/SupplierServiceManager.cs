using Application.DTOs;
using Application.DTOs.SupplierDTOs;
using Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ServiceManager
{
    public class SupplierServiceManager
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierServiceManager(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<List<SupplierDTO>> GetSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            var suppliersDto = suppliers.Select(x => new SupplierDTO
            {
                Id = x.ID,
                ContactName = x.ContactName,
                CompanyName = x.CompanyName,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address
            }).ToList();

            return suppliersDto;
        }

        public async Task<SupplierDTO> AddSupplier(CreateSupplierDTO supplierDTO)
        {
            try
            {
                var supplier = new Supplier
                {
                    ContactName = supplierDTO.ContactName,
                    CompanyName = supplierDTO.CompanyName,
                    PhoneNumber = supplierDTO.PhoneNumber,
                    Address = supplierDTO.Address
                };

                var createdSupplier = await _supplierRepository.AddAsync(supplier);

                return new SupplierDTO
                {
                    Id = createdSupplier.ID,
                    ContactName = createdSupplier.ContactName,
                    CompanyName = createdSupplier.CompanyName,
                    PhoneNumber = createdSupplier.PhoneNumber,
                    Address = createdSupplier.Address
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task UpdateSupplier(UpdateSupplierDTO updateSupplierDto)
        {
            try
            {
                if (updateSupplierDto.Id > 0)
                {
                    var updated = new Supplier
                    {
                        ID = updateSupplierDto.Id,
                        ContactName = updateSupplierDto.ContactName,
                        CompanyName = updateSupplierDto.CompanyName,
                        PhoneNumber = updateSupplierDto.PhoneNumber,
                        Address = updateSupplierDto.Address
                    };

                    await _supplierRepository.UpdateAsync(updated);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteSupplier(SupplierDTO supplierDTO)
        {
            try
            {
                var supplier = await _supplierRepository.GetByIdAsync(supplierDTO.Id);
                await _supplierRepository.DeleteAsync(supplier);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<SupplierDTO> GetSupplier(int id)
        {
            try
            {
                var supplier = await _supplierRepository.GetByIdAsync(id);

                // Null kontrolü ekliyoruz
                if (supplier == null)
                {
                    return null; // veya hata fırlatabiliriz
                }

                return new SupplierDTO
                {
                    Id = supplier.ID,
                    ContactName = supplier.ContactName,
                    CompanyName = supplier.CompanyName,
                    PhoneNumber = supplier.PhoneNumber,
                    Address = supplier.Address
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}