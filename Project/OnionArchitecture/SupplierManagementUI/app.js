// API URL alma fonksiyonu
const API_URL = () => document.getElementById('apiUrl').value;

// Global değişkenler
let isEditMode = false;

// Sayfa yüklendiğinde
document.addEventListener('DOMContentLoaded', () => {
    checkAuthentication();
    loadSuppliers();
});

// Token kontrolü - Kullanıcı giriş yapmış mı?
function checkAuthentication() {
    const token = localStorage.getItem('authToken');
    if (!token) {
        window.location.href = 'login.html';
        return;
    }

    const userName = localStorage.getItem('userName');
    displayUserInfo(userName);
}

// Kullanıcı bilgilerini header'da göster
function displayUserInfo(userName) {
    const header = document.querySelector('header p');
    if (header && userName) {
        header.innerHTML = `Hoş geldiniz, <strong>${userName}</strong>! <a href="#" onclick="logout()" style="color: white; margin-left: 20px; text-decoration: underline;">Çıkış Yap</a>`;
    }
}

// Çıkış yap
function logout() {
    localStorage.removeItem('authToken');
    localStorage.removeItem('userName');
    localStorage.removeItem('userEmail');
    window.location.href = 'login.html';
}

// Token'lı API isteği yapmak için yardımcı fonksiyon
async function fetchWithAuth(url, options = {}) {
    const token = localStorage.getItem('authToken');
    
    if (!token) {
        window.location.href = 'login.html';
        throw new Error('Token bulunamadı!');
    }

    const headers = {
        ...options.headers,
        'Authorization': `Bearer ${token}`
    };

    const response = await fetch(url, { ...options, headers });

    if (response.status === 401) {
        localStorage.removeItem('authToken');
        localStorage.removeItem('userName');
        localStorage.removeItem('userEmail');
        showAlert('⚠️ Oturum süresi doldu! Lütfen tekrar giriş yapın.', 'error');
        setTimeout(() => {
            window.location.href = 'login.html';
        }, 2000);
        throw new Error('Oturum süresi doldu!');
    }

    return response;
}

// Form submit event listener
document.getElementById('supplierForm').addEventListener('submit', async (e) => {
    e.preventDefault();
    
    const supplierId = document.getElementById('supplierId').value;
    
    if (isEditMode && supplierId) {
        await updateSupplier();
    } else {
        await addSupplier();
    }
});

// Tüm tedarikçileri yükle
async function loadSuppliers() {
    try {
        const response = await fetchWithAuth(`${API_URL()}/suppliers`);
        
        if (!response.ok) {
            throw new Error('Tedarikçiler yüklenemedi!');
        }

        const suppliers = await response.json();
        displaySuppliers(suppliers);
        updateStats(suppliers.length);
    } catch (error) {
        showAlert('Tedarikçiler yüklenirken hata oluştu: ' + error.message, 'error');
        document.getElementById('supplierList').innerHTML = '<div class="empty-state">❌ Veri yüklenemedi</div>';
    }
}

// Tedarikçileri tabloda göster
function displaySuppliers(suppliers) {
    const listContainer = document.getElementById('supplierList');

    if (suppliers.length === 0) {
        listContainer.innerHTML = `
            <div class="empty-state">
                <svg viewBox="0 0 24 24" fill="none" stroke="currentColor">
                    <path d="M20 7h-4V4c0-1.1-.9-2-2-2h-4c-1.1 0-2 .9-2 2v3H4c-1.1 0-2 .9-2 2v11c0 1.1.9 2 2 2h16c1.1 0 2-.9 2-2V9c0-1.1-.9-2-2-2zM10 4h4v3h-4V4zm10 15H4V9h16v10z"/>
                </svg>
                <h3>Henüz tedarikçi bulunmuyor</h3>
                <p>Yeni bir tedarikçi ekleyerek başlayın</p>
            </div>
        `;
        return;
    }

    let tableHTML = `
        <table class="supplier-table">
            <thead>
                <tr>
                    <th>#</th>
                    <th>İletişim Kişisi</th>
                    <th>Şirket Adı</th>
                    <th>Telefon</th>
                    <th>Adres</th>
                    <th>İşlemler</th>
                </tr>
            </thead>
            <tbody>
    `;

    suppliers.forEach((supplier, index) => {
        tableHTML += `
            <tr>
                <td>${index + 1}</td>
                <td>${supplier.contactName}</td>
                <td>${supplier.companyName}</td>
                <td>${supplier.phoneNumber}</td>
                <td>${supplier.address || '-'}</td>
                <td>
                    <div class="action-buttons">
                        <button class="btn-warning btn-small" onclick="editSupplier(${supplier.id})">Düzenle</button>
                        <button class="btn-danger btn-small" onclick="deleteSupplier(${supplier.id}, '${supplier.companyName}')">Sil</button>
                    </div>
                </td>
            </tr>
        `;
    });

    tableHTML += '</tbody></table>';
    listContainer.innerHTML = tableHTML;
}

// Yeni tedarikçi ekle
async function addSupplier() {
    const formData = new FormData();
    formData.append('ContactName', document.getElementById('contactName').value);
    formData.append('CompanyName', document.getElementById('companyName').value);
    formData.append('PhoneNumber', document.getElementById('phoneNumber').value);
    formData.append('Address', document.getElementById('address').value || '');

    try {
        const response = await fetchWithAuth(`${API_URL()}/add-supplier`, {
            method: 'POST',
            body: formData
        });

        if (response.ok) {
            showAlert('✅ Tedarikçi başarıyla eklendi!', 'success');
            resetForm();
            loadSuppliers();
        } else {
            throw new Error('Tedarikçi eklenemedi!');
        }
    } catch (error) {
        showAlert('❌ Hata: ' + error.message, 'error');
    }
}

// Tedarikçi düzenle - verileri forma yükle
async function editSupplier(id) {
    try {
        const response = await fetchWithAuth(`${API_URL()}/get-supplier?id=${id}`);
        
        if (!response.ok) {
            throw new Error('Tedarikçi bilgileri alınamadı!');
        }

        const supplier = await response.json();
        
        document.getElementById('supplierId').value = supplier.id;
        document.getElementById('contactName').value = supplier.contactName;
        document.getElementById('companyName').value = supplier.companyName;
        document.getElementById('phoneNumber').value = supplier.phoneNumber;
        document.getElementById('address').value = supplier.address || '';

        document.getElementById('formTitle').textContent = '✏️ Tedarikçi Düzenle';
        document.getElementById('submitBtn').textContent = 'Güncelle';
        isEditMode = true;

        document.querySelector('.form-section').scrollIntoView({ behavior: 'smooth' });
    } catch (error) {
        showAlert('❌ Hata: ' + error.message, 'error');
    }
}

// Tedarikçi güncelle
async function updateSupplier() {
    const data = {
        id: parseInt(document.getElementById('supplierId').value),
        contactName: document.getElementById('contactName').value,
        companyName: document.getElementById('companyName').value,
        phoneNumber: document.getElementById('phoneNumber').value,
        address: document.getElementById('address').value || ''
    };

    try {
        const response = await fetchWithAuth(`${API_URL()}/update-supplier`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            showAlert('✅ Tedarikçi başarıyla güncellendi!', 'success');
            resetForm();
            loadSuppliers();
        } else {
            throw new Error('Tedarikçi güncellenemedi!');
        }
    } catch (error) {
        showAlert('❌ Hata: ' + error.message, 'error');
    }
}

// Tedarikçi sil
async function deleteSupplier(id, companyName) {
    if (!confirm(`"${companyName}" tedarikçisini silmek istediğinize emin misiniz?`)) {
        return;
    }

    try {
        const response = await fetchWithAuth(`${API_URL()}/delete-supplier?id=${id}`, {
            method: 'DELETE'
        });

        if (response.ok) {
            showAlert('✅ Tedarikçi başarıyla silindi!', 'success');
            loadSuppliers();
        } else {
            throw new Error('Tedarikçi silinemedi!');
        }
    } catch (error) {
        showAlert('❌ Hata: ' + error.message, 'error');
    }
}

// Formu sıfırla
function resetForm() {
    document.getElementById('supplierForm').reset();
    document.getElementById('supplierId').value = '';
    document.getElementById('formTitle').textContent = '➕ Yeni Tedarikçi Ekle';
    document.getElementById('submitBtn').textContent = 'Kaydet';
    isEditMode = false;
}

// Alert mesajı göster
function showAlert(message, type) {
    const alertBox = document.getElementById('alertBox');
    alertBox.textContent = message;
    alertBox.className = `alert alert-${type} show`;

    setTimeout(() => {
        alertBox.classList.remove('show');
    }, 5000);
}

// İstatistikleri güncelle
function updateStats(total) {
    document.getElementById('totalSuppliers').textContent = total;
}