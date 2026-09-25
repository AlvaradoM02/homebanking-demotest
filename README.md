# 🏦 HomeBanking Demo Test

Suite de pruebas end-to-end para validar los flujos principales de un home banking demo. El proyecto utiliza **.NET 10**, **NUnit** y **Playwright** con el patrón Page Object Model.

Las pruebas se ejecutan contra la aplicación publicada en:

<https://homebanking-demo-tests.netlify.app/>

## ✨ Qué se valida

| Caso | Flujo | Validación principal |
| --- | --- | --- |
| `CP01` | Inicio de sesión | El usuario puede ingresar y visualizar el dashboard |
| `CP03` | Consulta de saldos | El saldo se muestra y puede ocultarse o volver a mostrarse |
| `CP04` | Transferencia | Se confirma una transferencia con saldo suficiente |

Las pruebas utilizan las credenciales demo:

```text
Usuario: demo
Contraseña: demo123
```

## 🧰 Tecnologías

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [NUnit 4](https://nunit.org/)
- [Microsoft Playwright for .NET](https://playwright.dev/dotnet/)
- `NUnit3TestAdapter`
- `Microsoft.NET.Test.Sdk`

## 🚀 Puesta en marcha

### Requisitos previos

- Windows, macOS o Linux
- .NET 10 SDK instalado
- PowerShell disponible para instalar los navegadores de Playwright
- Acceso a internet para abrir la aplicación demo y restaurar paquetes

Comprueba la versión de .NET:

```bash
dotnet --version
```

### 1. Clonar y entrar al proyecto

```bash
git clone https://github.com/AlvaradoM02/homebanking-demotest.git
cd homebanking-demotest
```

### 2. Restaurar dependencias

```bash
dotnet restore
```

### 3. Compilar

```bash
dotnet build
```

### 4. Instalar Chromium para Playwright

Ejecuta este comando después de compilar el proyecto:

```powershell
pwsh .\bin\Debug\net10.0\playwright.ps1 install chromium
```

En Windows también puedes ejecutarlo desde PowerShell con:

```powershell
.\bin\Debug\net10.0\playwright.ps1 install chromium
```

## 🧪 Ejecutar las pruebas

Ejecutar toda la suite:

```bash
dotnet test
```

Ejecutar un caso específico:

```bash
dotnet test --filter "FullyQualifiedName~CP01_LoginExitoso"
dotnet test --filter "FullyQualifiedName~CP03_ValidacionSaldos"
dotnet test --filter "FullyQualifiedName~CP04_TransferenciaSaldoSuficiente"
```

Para obtener más detalle en la consola:

```bash
dotnet test --logger "console;verbosity=detailed"
```

> Las pruebas interactúan con un sitio remoto. Si la aplicación demo no está disponible o cambia sus textos/selectores, los resultados pueden variar.

## 📸 Evidencias

Los casos generan capturas de pantalla durante la ejecución. Se guardan en la carpeta `capturas` dentro del directorio de ejecución, por ejemplo:

- `CP01-login-exitoso.png`
- `CP03-saldos-visibles.png`
- `CP03-saldo-oculto.png`
- `CP04-modal-confirmacion.png`
- `CP04-transferencia-exitosa.png`

Los directorios de compilación, resultados locales y capturas generadas están excluidos del control de versiones mediante [`.gitignore`](./.gitignore).

## 📁 Estructura

```text
.
├── Pages/
│   ├── DashboardPage.cs
│   ├── LoginPage.cs
│   └── TransferenciasPage.cs
├── Tests/
│   ├── CP01_LoginExitoso.cs
│   ├── CP03_ValidacionSaldos.cs
│   └── CP04_TransferenciaSaldoSuficiente.cs
├── HomeBankingDemoTest.csproj
└── README.md
```

### Organización del código

- `Pages/`: encapsula navegación, localizadores y acciones de cada pantalla.
- `Tests/`: contiene los casos de prueba y sus validaciones.
- `HomeBankingDemoTest.csproj`: define el framework objetivo y las dependencias NuGet.

## 🔧 Convenciones para contribuir

1. Crea o actualiza una clase Page Object cuando cambie la interacción con una pantalla.
2. Mantén los pasos de negocio y las aserciones en `Tests/`.
3. Usa nombres de prueba descriptivos y conserva el identificador del caso (`CPxx`).
4. Ejecuta `dotnet build` y `dotnet test` antes de abrir un pull request.
5. No agregues credenciales reales ni archivos generados al repositorio.

## 📝 Reportes

El adaptador de NUnit permite generar resultados compatibles con los formatos habituales de `dotnet test`. Para guardar un resultado `.trx`:

```bash
dotnet test --logger "trx;LogFileName=resultados.trx"
```

El archivo se genera en el directorio de resultados configurado por el runner.
