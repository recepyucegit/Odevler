// ==========================================
// SUPPLIER-CLIENT.JS
// ==========================================

// API Base URL
const API_BASE_URL = 'https://localhost:7046'; // API port'unu değiştirin

// Global değişkenler
let authToken = null;
let currentUser = null;
let categories = [];

// Sayfa yüklendiğinde
document.addEventListener('DOMContentLoaded', function () {
    // Login form submit
    document.getElementById('loginForm').addEventListener('submit', function (e) {
        e.preventDefault();
        login();
    });

    // Add product form submit
    document.getElementById('addProductForm').addEventListener('submit', function (e) {
        e.preventDefault();
        addProduct();
    });

    // Token kontrolü
    checkAuth();
});

// Authentication kontrolü
function checkAuth() {
    const token = localStorage.getItem('authToken');
    const user = localStorage.getItem('currentUser');

    if (token && user) {
        authToken = token;
        currentUser = JSON.parse(user);
        showMainPanel();
    }
}

// Login işlemi
async function login() {
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    try {
        const response = await fetch(`${API_BASE_URL}/auth/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ username, password })
        });

        const result = await response.json();

        if (result.success) {
            // Token ve kullanıcı bilgilerini sakla
            authToken = result.data.token;
            currentUser = result.data;

            localStorage.setItem('authToken', authToken);
            localStorage.setItem('currentUser', JSON.stringify(currentUser));

            showToast('Giriş başarılı!', 'success');
            showMainPanel();
        } else {
            showToast(result.message || 'Giriş başarısız!', 'danger');
        }
    } catch (error) {
        showToast('Bağlantı hatası: ' + error.message, 'danger');
    }
}

// Ana paneli göster
function showMainPanel() {
    document.getElementById('loginContainer').style.display = 'none';
    document.getElementById('mainContainer').style.display = 'block';

    // Kullanıcı bilgilerini göster
    document.getElementById('companyName').textContent = currentUser.companyName;

    // Yetkileri göster
    const permissionList = document.getElementById('permissionList');
    permissionList.innerHTML = '';

    currentUser.permissions.forEach(permission => {
        let badgeColor = 'bg-secondary';
        let permissionText = '';

        switch (permission) {
            case 'ReadProduct':
                badgeColor = 'bg-info';
                permissionText = 'Ürün Görüntüleme';
                break;
            case 'AddProduct':
                badgeColor = 'bg-success';
                permissionText = 'Ürün Ekleme';
                break;
            case 'EditProduct':
                badgeColor = 'bg-warning text-dark';
                permissionText = 'Ürün Düzenleme';
                break;
            case 'DeleteProduct':
                badgeColor = 'bg-danger';
                permissionText = 'Ürün Silme';
                break;
        }

        permissionList.innerHTML += `
            <span class="badge ${badgeColor} permission-badge">${permissionText}</span>
        `;
    });

    // Yetkilere göre panelleri göster/gizle
    if (currentUser.permissions.includes('AddProduct')) {
        document.getElementById('addProductPanel').style.display = 'block';
        document.getElementById('productListPanel').classList.remove('col-md-8');
        document.getElementById('productListPanel').classList.add('col-md-8');
    } else {
        document.getElementById('addProductPanel').style.display = 'none';
        document.getElementById('productListPanel').classList.remove('col-md-8');
        document.getElementById('productListPanel').classList.add('col-md-12');
    }

    // Kategorileri ve ürünleri yükle
    loadCategories();
    loadProducts();
}

// Kategorileri yükle
async function loadCategories() {
    try {
        const response = await fetch(`${API_BASE_URL}/product/categories`, {
            headers: {
                'Authorization': `Bearer ${authToken}`
            }
        });

        const result = await response.json();

        if (result.success) {
            categories = result.data;

            // Kategori selectbox'larını doldur
            const categorySelect = document.getElementById('categoryId');
            const editCategorySelect = document.getElementById('editCategoryId');

            categorySelect.innerHTML = '<option value="">Seçiniz...</option>';
            editCategorySelect.innerHTML = '<option value="">Seçiniz...</option>';

            categories.forEach(category => {
                const option = `<option value="${category.id}">${category.categoryName}</option>`;
                categorySelect.innerHTML += option;
                editCategorySelect.innerHTML += option;
            });
        }
    } catch (error) {
        console.error('Kategoriler yüklenemedi:', error);
    }
}

// Ürünleri yükle
async function loadProducts() {
    document.getElementById('loadingSpinner').style.display = 'block';
    document.getElementById('productTable').style.display = 'none';

    try {
        const response = await fetch(`${API_BASE_URL}/product`, {
            headers: {
                'Authorization': `Bearer ${authToken}`
            }
        });

        const result = await response.json();

        if (result.success) {
            displayProducts(result.data);
        } else {
            showToast('Ürünler yüklenemedi: ' + result.message, 'danger');
        }
    } catch (error) {
        showToast('Bağlantı hatası: ' + error.message, 'danger');
    } finally {
        document.getElementById('loadingSpinner').style.display = 'none';
        document.getElementById('productTable').style.display = 'table';
    }
}

// Ürünleri tabloda göster
function displayProducts(products) {
    const tbody = document.getElementById('productTableBody');
    tbody.innerHTML = '';

    products.forEach(product => {
        let actions = '';

        // Yetkilere göre butonları göster
        if (currentUser.permissions.includes('EditProduct')) {
            actions += `
                <button class="btn btn-sm btn-warning me-1" onclick="editProduct(${product.id})">
                    <i class="bi bi-pencil"></i>
                </button>
            `;
        }

        if (currentUser.permissions.includes('DeleteProduct')) {
            actions += `
                <button class="btn btn-sm btn-danger" onclick="deleteProduct(${product.id}, '${product.productName}')">
                    <i class="bi bi-trash"></i>
                </button>
            `;
        }

        if (actions === '') {
            actions = '<span class="text-muted">Yetkiniz yok</span>';
        }

        const row = `
            <tr>
                <td>${product.id}</td>
                <td>${product.productName}</td>
                <td>${product.categoryName || '-'}</td>
                <td>${product.unitPrice.toFixed(2)} ₺</td>
                <td>
                    <span class="badge ${product.unitsInStock > 10 ? 'bg-success' : 'bg-warning'}">
                        ${product.unitsInStock}
                    </span>
                </td>
                <td>${actions}</td>
            </tr>
        `;

        tbody.innerHTML += row;
    });
}

// Ürün ekle
async function addProduct() {
    const productData = {
        productName: document.getElementById('productName').value,
        description: document.getElementById('productDescription').value,
        unitPrice: parseFloat(document.getElementById('unitPrice').value),
        unitsInStock: parseInt(document.getElementById('unitsInStock').value),
        categoryId: parseInt(document.getElementById('categoryId').value)
    };

    try {
        const response = await fetch(`${API_BASE_URL}/product`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${authToken}`
            },
            body: JSON.stringify(productData)
        });

        const result = await response.json();

        if (response.ok && result.success) {
            showToast('Ürün başarıyla eklendi!', 'success');
            document.getElementById('addProductForm').reset();
            loadProducts();
        } else {
            showToast(result.message || 'Ürün eklenemedi!', 'danger');
        }
    } catch (error) {
        showToast('Bağlantı hatası: ' + error.message, 'danger');
    }
}

// Ürün düzenle
async function editProduct(productId) {
    try {
        const response = await fetch(`${API_BASE_URL}/product/${productId}`, {
            headers: {
                'Authorization': `Bearer ${authToken}`
            }
        });

        const result = await response.json();

        if (result.success) {
            const product = result.data;

            // Form alanlarını doldur
            document.getElementById('editProductId').value = product.id;
            document.getElementById('editProductName').value = product.productName;
            document.getElementById('editProductDescription').value = product.description || '';
            document.getElementById('editUnitPrice').value = product.unitPrice;
            document.getElementById('editUnitsInStock').value = product.unitsInStock;
            document.getElementById('editCategoryId').value = product.categoryId;

            // Modal'ı aç
            const modal = new bootstrap.Modal(document.getElementById('editModal'));
            modal.show();
        }
    } catch (error) {
        showToast('Ürün bilgileri alınamadı: ' + error.message, 'danger');
    }
}

// Ürün güncelle
async function updateProduct() {
    const productId = document.getElementById('editProductId').value;
    const productData = {
        productName: document.getElementById('editProductName').value,
        description: document.getElementById('editProductDescription').value,
        unitPrice: parseFloat(document.getElementById('editUnitPrice').value),
        unitsInStock: parseInt(document.getElementById('editUnitsInStock').value),
        categoryId: parseInt(document.getElementById('editCategoryId').value)
    };

    try {
        const response = await fetch(`${API_BASE_URL}/product/${productId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${authToken}`
            },
            body: JSON.stringify(productData)
        });

        const result = await response.json();

        if (response.ok && result.success) {
            showToast('Ürün başarıyla güncellendi!', 'success');

            // Modal'ı kapat
            const modal = bootstrap.Modal.getInstance(document.getElementById('editModal'));
            modal.hide();

            // Ürünleri yeniden yükle
            loadProducts();
        } else {
            showToast(result.message || 'Ürün güncellenemedi!', 'danger');
        }
    } catch (error) {
        showToast('Bağlantı hatası: ' + error.message, 'danger');
    }
}

// Ürün sil
async function deleteProduct(productId, productName) {
    if (!confirm(`"${productName}" ürününü silmek istediğinizden emin misiniz?`)) {
        return;
    }

    try {
        const response = await fetch(`${API_BASE_URL}/product/${productId}`, {
            method: 'DELETE',
            headers: {
                'Authorization': `Bearer ${authToken}`
            }
        });

        const result = await response.json();

        if (response.ok && result.success) {
            showToast('Ürün başarıyla silindi!', 'success');
            loadProducts();
        } else {
            showToast(result.message || 'Ürün silinemedi!', 'danger');
        }
    } catch (error) {
        showToast('Bağlantı hatası: ' + error.message, 'danger');
    }
}

// Çıkış yap
function logout() {
    localStorage.removeItem('authToken');
    localStorage.removeItem('currentUser');

    authToken = null;
    currentUser = null;

    document.getElementById('loginContainer').style.display = 'block';
    document.getElementById('mainContainer').style.display = 'none';

    showToast('Çıkış yapıldı', 'info');
}

// Toast mesajı göster
function showToast(message, type) {
    const toastContainer = document.querySelector('.toast-container');
    const toastId = 'toast-' + Date.now();

    const toastHtml = `
        <div id="${toastId}" class="toast align-items-center text-white bg-${type} border-0" role="alert">
            <div class="d-flex">
                <div class="toast-body">
                    ${message}
                </div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
            </div>
        </div>
    `;

    toastContainer.innerHTML += toastHtml;

    const toastElement = document.getElementById(toastId);
    const toast = new bootstrap.Toast(toastElement);
    toast.show();

    // 5 saniye sonra DOM'dan kaldır
    setTimeout(() => {
        toastElement.remove();
    }, 5000);
}