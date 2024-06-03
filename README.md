DesktopLayoutSaver
Table of Contents
Introduction
Features
Target Audience
Technologies Used
Installation and Setup
Usage
Project Structure
Contributing
License
Introduction
DesktopLayoutSaver is a Windows WPF application designed to save and restore the positions and sizes of all open windows on your desktop. This tool is especially useful for users who work with multiple monitor setups in different environments (e.g., a dual monitor setup at home and a triple monitor setup at the office) and want to quickly switch between different window layouts.

Features
Save Window Profiles: Capture the positions and sizes of all open windows and save them as a named profile.
Restore Window Profiles: Restore previously saved window profiles, positioning and resizing windows to their saved states.
Delete Window Profiles: Remove unwanted window profiles from the application.
Simple and Clean UI: User-friendly interface for easy management of window profiles.
Lightweight: Designed to use minimal system resources while running in the background.
Target Audience
This application is intended for:

Professionals who frequently switch between different multi-monitor setups and need their application windows to be arranged in a specific way.
Remote workers who use Remote Desktop Protocol (RDP) and want to maintain consistent window layouts between their home and office environments.
Anyone looking for a simple solution to manage window positions and sizes on their desktop.
Technologies Used
.NET Core: The application is built using the .NET Core framework.
WPF (Windows Presentation Foundation): Utilized for creating the graphical user interface.
C#: The primary programming language used to develop the application.
Newtonsoft.Json: A popular JSON framework for .NET used to handle the serialization and deserialization of window profiles.
Installation and Setup
Prerequisites
Windows operating system (Windows 7 or later)
.NET Core SDK installed on your machine
Steps
Clone the Repository

bash
Copy code
git clone https://github.com/yourusername/DesktopLayoutSaver.git
cd DesktopLayoutSaver
Install Dependencies

Open the project in Visual Studio and restore NuGet packages.

Build the Project

Build the solution in Visual Studio to ensure all dependencies are correctly configured.

Run the Application

Start the application by running the DesktopLayoutSaver project in Visual Studio.

Usage
Save a Profile

Enter a profile name in the text box.
Click the "Save Profile" button.
The current window layout will be saved under the specified profile name.
Restore a Profile

Select a profile from the list of saved profiles.
Click the "Restore Profile" button.
The windows will be arranged to match the saved layout of the selected profile.
Delete a Profile

Select a profile from the list of saved profiles.
Click the "Delete Profile" button.
The selected profile will be removed from the list.
Project Structure
plaintext
Copy code
DesktopLayoutSaver/
├── DesktopLayoutSaver.sln         # Solution file
├── App.xaml                       # Application definition file
├── App.xaml.cs                    # Application definition code-behind
├── MainWindow.xaml                # Main window UI definition
├── MainWindow.xaml.cs             # Main window code-behind
├── ProfileManager.cs              # Profile manager logic
├── Profile.cs                     # Profile data structure
├── WindowInfo.cs                  # Window information and manipulation
└── Profiles.json                  # JSON file storing the profiles (generated at runtime)
Contributing
Contributions are welcome! If you have suggestions for improvements or new features, please create an issue or submit a pull request.

Steps to Contribute
Fork the repository.
Create a new branch (git checkout -b feature-branch).
Make your changes.
Commit your changes (git commit -m 'Add some feature').
Push to the branch (git push origin feature-branch).
Open a pull request.
License
This project is licensed under the MIT License. See the LICENSE file for more details.
