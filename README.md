# FlaUI Automation Framework Template

This repository provides a **lightweight template for desktop UI test automation** using **FlaUI** and **.NET**.

The goal of this project is to demonstrate a **clean and maintainable framework structure** for automating Windows desktop applications, with a clear separation of responsibilities and scalability in mind.

---

## Purpose

- Serve as a **starting point** for FlaUI-based desktop automation projects
- Demonstrate **framework architecture** rather than application-specific tests
- Provide a reference structure suitable for **enterprise and legacy systems**

This is intentionally a **template**, not a complete test suite.

---

## Technology Stack

- **C# / .NET**
- **FlaUI**
- **UI Automation (Windows)**
- **Visual Studio Code**

> The project is developed on macOS using Visual Studio Code.  
> Test execution is intended to run on **Windows environments only**.

---

## Project Structure

├── Locators/ # UI element identifiers and selectors

├── PO/ # Page Object / Screen Object models

├── Shared/ # Shared utilities, helpers, and configuration

├── Tests/ # Test scenarios and test classes

├── Local.runsettings

└── README.md


---

## Execution

- Tests are designed to be executed on **Windows machines** where the target desktop application is available.
- The framework can be integrated into **Windows-based CI pipelines** (e.g. Azure DevOps, GitHub Actions) if needed.

> CI configuration is intentionally excluded to keep this repository framework-focused.

---

## Notes

- This repository does **not** contain application-specific logic.
- No production credentials, test data, or company-specific code is included.
- The structure is designed to be easily extended for real-world projects.

---

## Author

Bohdan Reshetilov  
QA Automation Engineer / SDET
