# TipCalculatorPart1

## Project Overview

### Motivation  
The project originated from a desire to attain a thorough and comprehensive understanding of the MVVM architecture and its associated concepts, particularly the use of commands for managing user interactions. Initially motivated by the educational value of exploring MVVM, the project evolved to evaluate its differences from MVC and understand the practical trade-offs between the two. Additionally, the project provided an opportunity to learn how to use and manipulate APIs.

### Goal  
To explore and solidify understanding of MVVM architecture, including the use of commands over event handlers, and evaluate differences from MVC. The project ultimately transitioned to MVC to align with the app's scope and simplify development while maintaining functionality and user experience.

### Value Proposition  
Streamline bill calculations with the user-friendly slider-based tip calculator. Designed for simplicity and accuracy, it makes splitting bills effortless for any dining experience.

## Features

### Core Functionalities  
- Input a bill amount.  
- Select a tip percentage via a slider.  
- Calculate the total and per-person share, adjustable with a stepper for the number of diners.

### Innovative Features  
- A combination of functionalities designed to simplify calculations while enhancing user engagement and convenience.

## Architecture

### Overview  
MVC was chosen for its simplicity, with model properties exposed via code-behind and bound to UI elements. Updates were managed by invoking `OnPropertyChanged` within property setters, implicitly for the direct property being set and explicitly for affected properties.

### Patterns  
- **Why MVC?**  
  The application's complexity did not justify the need for MVVM. The app is not intended for extensibility, and introducing a ViewModel would have only invoked the model's properties, adding unnecessary complexity without significant benefit.
  
- **Event Handlers over Commands**  
  Event handlers were preferred, as MVC already introduces tight coupling between the logic and the View. Additional coupling via commands was deemed redundant.  

- **Binding Context**  
  The binding context was set in the code-behind file to avoid recursion errors encountered when defining it in XAML.

## Tech Stack

### Programming Languages  
- C#

### Frameworks and Libraries  
- **Syncfusion.Maui.Sliders (29.1.35)**: Slider component for tip percentage selection.  
- **Microsoft.Maui.Controls (9.0.50)**: UI framework for building user interfaces in the .NET MAUI application.  
- **Microsoft.Extensions.Logging.Debug (9.03)**: Enhanced logging for debugging during development.

### Tools  
- **Visual Studio Code (1.99.0)**: For writing and refining the README file.  
- **Microsoft Visual Studio Community 2022 (17.13.5)**: IDE used for creating and debugging the application.  
- **Git (2.45.1.windows.1)**: Version control system for managing code changes and tracking project history.  
- **GitHub**: Remote repository platform for storing the project and enabling centralized access.

## Installation and Usage

### Pre-requisites
1. Ensure the following are installed on your system:  
   - [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (version 6.0 or later).  
   - Visual Studio 2022 Community Edition or higher with the .NET MAUI workload installed.  
   - Git (version 2.45 or later) for version control.

2. Clone the repository from GitHub:  
   ```bash
   git clone https://github.com/Learner062022/TipCalculator.git
   ```

### Step-by-step Instructions
- **Open the Project**  
  - Launch Visual Studio 2022 Community Edition.  
  - Open the cloned project by navigating to the folder containing the `.csproj` file.  

- **Build the Solution**  
  - In Visual Studio, navigate to *Build* > *Build Solution* (or use the shortcut `Ctrl + Shift + B`).  

- **Run the Application**  
  - Click the *Start* button or press `F5` to debug and run the application.  
  - The app will launch in the specified simulator/emulator or on your connected physical device.  

### Troubleshooting
- **Common Errors**  
  - **Missing Dependencies**  
    Ensure all required NuGet packages are restored by running:  
    ```bash
    dotnet restore
    ```

  - **Build Errors**  
    Confirm that all project references and bindings are correct in the `.csproj` file.  

- **Simulator Issues**  
  - Restart your development environment if the emulator/simulator fails to load.  
  - For physical devices, ensure developer mode is enabled.  

## Testing and Validation
The application was manually tested to ensure functionality, responsiveness, and performance accuracy. This included:
- Verifying controls such as sliders, steppers, and buttons triggered immediate and accurate updates.
- Testing calculations dynamically based on user inputs, such as adjusting totals when the tip percentage slider is moved.
- Exploring interdependencies between inputs to ensure consistent calculations, e.g.:
  - When the tip percentage slider is set to 0, the total matches the bill amount.
  - With a non-zero slider value, the total correctly reflects the sum of the bill amount and calculated tip.
  - Split amounts dynamically update based on the total and number of diners.

## Limitations
- Lack of automated testing frameworks (e.g., NUnit, xUnit) limits validation of edge cases and long-term reliability.
- Flexible splitting logic supports equal splits but does not accommodate advanced features like uneven bill-splitting.
- No data persistence—calculations cannot be saved or retrieved from past sessions.
- Manual testing only, which restricts broad validation and reproducibility.
- Input format does not enforce currency specifications, relying on direct entry via buttons.
- Limited optimization and testing for diverse device types, sizes, and operating systems.

## Future Improvements

### Planned Features
- Add advanced bill-splitting options, allowing uneven splits based on specific charges for individual diners.
- Implement persistent storage for user calculations to enable retrieval of past sessions.
- Optimize compatibility across varying screen sizes, device types, and operating systems.
- Introduce support for multiple currencies and automatic formatting.

### Enhanced Testing
- Systematically implement automated testing frameworks (e.g., NUnit, xUnit) to ensure comprehensive validation and reliability.

## Contributing

### Guidelines
- Adhere to [Google's Style Guides](https://google.github.io/styleguide/) or [Microsoft's C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions) for clean and maintainable code.
- Provide detailed descriptions of changes and link related issues in all pull requests.

### Branching Strategy
- Follow [Conventional Commits](https://www.conventionalcommits.org/) for commit message formatting. Use branch naming conventions such as:
  - `feature/<description>`: For new features.
  - `fix/<description>`: For bug fixes.
  - `hotfix/<description>`: For critical fixes.
- Refer to [Microsoft's Branching Guidance](https://learn.microsoft.com/en-us/azure/devops/repos/git/git-branching-guidance?view=azure-devops) or [GitKraken's Git Branching Strategies](https://www.gitkraken.com/learn/git/best-practices/git-branch-strategy) for workflows:
  - Branch off from the latest `main`.
  - Regularly sync branches with `main` and ensure thorough testing prior to pull requests.

### Pull Requests
- Submit all pull requests to the `main` branch following [GitHub's Pull Request Guide](https://docs.github.com/en/pull-requests/collaborating-with-pull-requests/getting-started/about-pull-requests).
- Ensure new features or updates are well-documented. Refer to [Atlassian's Pull Request Guide](https://www.atlassian.com/blog/git/written-unwritten-guide-pull-requests) for best practices.

## Known Issues
- Equal bill splitting only; uneven splits or additional charges per diner are not supported.
- Certain inputs, such as excessively large numbers, may not be handled gracefully.
- Limited testing across unique device configurations may result in UI inconsistencies.

## License
The project is licensed under the [GPL-3.0 License](https://www.gnu.org/licenses/gpl-3.0.en.html).
