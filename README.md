# 🧾 SecureQRFields - App de Configuración Local

Aplicación de escritorio en C# (.NET Framework 4.8) que permite ingresar campos personalizados, elegir si se desean encriptar, hashear o dejar en texto plano, y luego generar un código QR que contiene toda la información en formato JSON, útil para compartir configuraciones de forma segura entre sistemas.

---

## 📦 Características principales

- Generación de QR en base a datos personalizados (ej. conexión a base de datos, usuario, IP).
- Opción para:
  - Ingresar campos de forma manual
  - Encriptar (AES) o hashear (SHA256) valores seleccionados
  - Exportar el contenido como código QR con formato JSON
  - Lectura de QR compatible con Xamarin Forms y otras plataformas

---

## 🧱 Arquitectura del proyecto

El proyecto sigue una estructura por capas para mantener el código organizado y escalable:


``` text
SecureQRFields/
├── SecureQRFields.sln               # Solución principal del proyecto
│
├── Models/                          # Clases de datos utilizadas por el sistema
│   └── FieldEntry.cs                # Representa un campo dinámico con su valor y tipo (plano, encriptado, hasheado)
│
├── Services/                        # Lógica de negocio central
│   ├── EncryptionService.cs         # Servicio para encriptar y desencriptar usando AES
│   ├── HashService.cs               # Servicio para generar hashes SHA256
│   └── QRService.cs                 # Servicio para generar códigos QR a partir de JSON
│
├── Utils/                           # Utilidades y funciones auxiliares
│   └── JsonHelper.cs                # Función para convertir la lista de campos a JSON
│
├── Views/                           # Formularios secundarios (modal de QR, ayuda, etc.)
│   └── QRPreviewForm.cs             # Ventana para previsualizar el código QR generado
|
├── .gitignore                       # Archivos y carpetas ignoradas por Git
├── App.config                       # Configuración de la aplicación (conexión, settings)
│
├── FormMain.cs                      # Formulario principal de la aplicación
├── Program.cs                       # Punto de entrada de la aplicación
│
└── README.md                        # Documentación principal del proyecto
```

---

## 🚀 Tecnologías utilizadas

- C# con .NET Framework 4.8
- Windows Forms
- [QRCoder](https://github.com/codebude/QRCoder) (Generación de códigos QR)
- [Newtonsoft.Json](https://www.newtonsoft.com/json) (Serialización JSON)
- System.Security.Cryptography (AES/SHA256)

---

## 🛠 Instalación y ejecución

1. Cloná el repositorio:
   ```bash
   git clone https://github.com/Santizo00/SecureQRFields.git
   ```
2. Abrí el proyecto en Visual Studio.
3. Restaurá los paquetes NuGet necesarios (QRCoder y Newtonsoft.Json).
4. Compilá y ejecutá la aplicación.

---

## 🧪 Cómo usar la app

1. Abrí la app.
2. Ingresá los campos: nombre del campo y valor.
3. Seleccioná si el valor debe ir en:
   - Texto plano
   - Encriptado (AES)
   - Hasheado (SHA256)
4. Presioná **"Generar QR"**.
5. Se mostrará el código QR que contiene el JSON con los datos protegidos.
6. Escanealo desde otro sistema (Xamarin Forms u otro) y procesá el contenido.

---

## 👤 Autor

Desarrollado por [Axel Santizo](https://github.com/Santizo00)