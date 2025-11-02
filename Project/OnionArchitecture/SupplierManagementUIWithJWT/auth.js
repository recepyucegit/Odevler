const API_BASE_URL = 'https://localhost:7266/api';

// Login Form
const loginForm = document.getElementById('loginForm');
if (loginForm) {
    loginForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        await handleLogin();
    });
}

// Register Form
const registerForm = document.getElementById('registerForm');
if (registerForm) {
    registerForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        await handleRegister();
    });
}

async function handleLogin() {
    const userNameOrEmail = document.getElementById('userNameOrEmail').value;
    const password = document.getElementById('password').value;
    const btn = document.querySelector('.btn-login');
    const btnText = btn.querySelector('.btn-text');
    const btnLoader = btn.querySelector('.btn-loader');

    // Button loading state
    btn.disabled = true;
    btnText.style.display = 'none';
    btnLoader.style.display = 'inline-block';

    try {
        const response = await fetch(`${API_BASE_URL}/Auth/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                userNameOrEmail: userNameOrEmail,
                password: password
            })
        });

        if (!response.ok) {
            const error = await response.json();
            throw new Error(error.message || 'Giriş başarısız!');
        }

        const data = await response.json();
        
        // Token'ı localStorage'a kaydet
        localStorage.setItem('authToken', data.token);
        localStorage.setItem('userName', data.userName);
        localStorage.setItem('userEmail', data.email);

        showAlert('✅ Giriş başarılı! Yönlendiriliyorsunuz...', 'success');

        // Ana sayfaya yönlendir
        setTimeout(() => {
            window.location.href = 'index.html';
        }, 1000);

    } catch (error) {
        showAlert('❌ ' + error.message, 'error');
        
        // Reset button
        btn.disabled = false;
        btnText.style.display = 'inline-block';
        btnLoader.style.display = 'none';
    }
}

async function handleRegister() {
    const userName = document.getElementById('userName').value;
    const email = document.getElementById('email').value;
    const phoneNumber = document.getElementById('phoneNumber').value;
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirmPassword').value;
    const btn = document.querySelector('.btn-login');
    const btnText = btn.querySelector('.btn-text');
    const btnLoader = btn.querySelector('.btn-loader');

    // Şifre kontrolü
    if (password !== confirmPassword) {
        showAlert('❌ Şifreler eşleşmiyor!', 'error');
        return;
    }

    // Button loading state
    btn.disabled = true;
    btnText.style.display = 'none';
    btnLoader.style.display = 'inline-block';

    try {
        const response = await fetch(`${API_BASE_URL}/Auth/register`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                userName: userName,
                email: email,
                phoneNumber: phoneNumber || null,
                password: password,
                confirmPassword: confirmPassword
            })
        });

        if (!response.ok) {
            const error = await response.json();
            throw new Error(error.errors ? error.errors.join(', ') : error.message || 'Kayıt başarısız!');
        }

        showAlert('✅ Kayıt başarılı! Giriş sayfasına yönlendiriliyorsunuz...', 'success');

        setTimeout(() => {
            window.location.href = 'login.html';
        }, 2000);

    } catch (error) {
        showAlert('❌ ' + error.message, 'error');
        
        // Reset button
        btn.disabled = false;
        btnText.style.display = 'inline-block';
        btnLoader.style.display = 'none';
    }
}

function showAlert(message, type) {
    const alertBox = document.getElementById('alertBox');
    alertBox.textContent = message;
    alertBox.className = `alert alert-${type} show`;

    setTimeout(() => {
        alertBox.classList.remove('show');
    }, 5000);
}