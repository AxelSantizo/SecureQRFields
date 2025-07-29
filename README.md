# 🧾 SecureQRFields - App de Configuración Local

Aplicación de escritorio en C# (.NET Framework 4.8) que permite ingresar campos personalizados, elegir si se desean encriptar, hashear o dejar en texto plano, y luego generar un código QR que contiene toda la información en formato JSON, útil para compartir configuraciones de forma segura entre sistemas.

---

## 📦 Características principales

- Generación de QR en base a datos personalizados o desde configuración remota.
- Opción para:
  - Ingresar campos manualmente
  - Cargar configuración automáticamente desde base de datos (dbsucursales)
  - Encriptar (AES) o hashear (SHA256) valores seleccionados
  - Exportar el contenido como código QR con formato JSON
  - Lectura de QR compatible con Xamarin Forms y otras plataformas

---

## 🧱 Arquitectura del proyecto

El proyecto sigue una estructura por capas para mantener el código organizado y escalable:

```text
SecureQRFields/
├── SecureQRFields.sln
│
├── Models/
│   ├── FieldEntry.cs                 # Representa un campo dinámico
│   └── SucursalConnectionInfo.cs     # Representa los datos de una sucursal remota
│
├── Services/
│   ├── EncryptionService.cs          # AES CBC con padding PKCS7
│   ├── HashService.cs                # SHA256
│   └── QRService.cs                  # Generación de código QR
│
├── Data/
│   └── SucursalRepository.cs         # Obtención de sucursales desde dbsucursales
│
├── Utils/
│   └── JsonHelper.cs                 # Conversión de campos a JSON
│
├── Views/
│   └── QRPreviewForm.cs              # Vista para previsualizar el QR
│
├── App.config                        # Configuraciones generales
├── FormMain.cs                       # Lógica principal de la app
├── Program.cs                        # Entry point
└── README.md                         # Documentación del proyecto

```

---

## 🚀 Tecnologías utilizadas

- C# con .NET Framework 4.8
- Windows Forms
- [QRCoder](https://github.com/codebude/QRCoder) (Generación de códigos QR)
- [Newtonsoft.Json](https://www.newtonsoft.com/json) (Serialización JSON)
- System.Security.Cryptography (AES/SHA256)
- MySql.Data (Acceso a base de datos MySQL)

---

## 🛠 Instalación y ejecución

1. Cloná el repositorio:
   ```bash
   git clone https://github.com/Santizo00/SecureQRFields.git
   ```
2. Abrí el proyecto en Visual Studio.
3. Restaurá los paquetes NuGet necesarios (QRCoder, Newtonsoft.Json y MySql.Data).
4. Compilá y ejecutá la aplicación.

---

## 🧪 Cómo usar la app

### Modo manual
1. Ingresá los campos: nombre, valor y codificación.
2. Presioná "Generar QR".
3. Se mostrará el código QR con los datos protegidos.

### Modo automático
1. Seleccioná una sucursal desde el ComboBox superior.
2. Los campos de conexión serán cargados automáticamente y encriptados.
3. El código QR se generará automáticamente sin presionar ningún botón.
4. Escanealo desde otro sistema (Xamarin Forms, etc.) para obtener los datos.

---

## 👤 Autor

Desarrollado por [Axel Santizo](https://github.com/Santizo00)