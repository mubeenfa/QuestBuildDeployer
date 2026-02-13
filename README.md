# QuestBuildDeployer
A lightweight Windows desktop tool for uploading APK builds directly to the Meta Horizon Store using Meta’s official **ovr-platform-util** CLI.

🚀 Meta Quest APK Deployer
==========================
A lightweight Windows desktop tool for uploading **Unity VR APK builds** directly to the **Meta Horizon Store** using Meta’s official ovr-platform-util CLI.
Designed for fast internal deployment workflows without CI/CD complexity.


✨ Overview
----------
This tool wraps the official Meta CLI and provides:
*   Simple UI
*   Real-time log streaming
*   Manual token-based authentication
*   Channel selection support
*   Single EXE deployment

No browser uploads. No dashboard navigation. Just build → deploy.


🛠 Tech Stack
-------------
*   WPF (.NET 8)
*   C#
*   Process execution via ProcessStartInfo
*   Official Meta CLI (ovr-platform-util.exe)


📦 Features
-----------
*   Select APK build
*   Enter App ID
*   Enter App Secret
*   Select Meta CLI Path
*   Choose release channel:
    *   ALPHA
    *   BETA
    *   RC
    *   LIVE
*   Real-time CLI output
*   Exit code detection
*   Self-contained EXE publish option
    

📋 Requirements
---------------
Before using this tool, ensure:
*   Meta Developer Account created
*   Organization created
*   Quest app created in Meta Dashboard
*   Developer Distribution Agreement signed
*   ovr-platform-util.exe downloaded
    

Official CLI reference:[https://developers.meta.com/horizon/resources/publish-reference-platform-command-line-utility/](https://developers.meta.com/horizon/resources/publish-reference-platform-command-line-utility/?utm_source=chatgpt.com)

🖼 App Preview
-------------
1.  App running with logs visible
   ![App Preview](https://github.com/mubeenfa/QuestBuildDeployer/screenshots/MetaPublisher Logs.png)

2. Successful deployment on Meta Developer Account
   ![Deployment UI](https://github.com/mubeenfa/QuestBuildDeployer/screenshots/Meta Developer Acc - Build Uploaded Details.png)

⚙️ Unity Build Requirements (Quest Store)
-----------------------------------------
Your APK must meet Meta requirements:
*   Target API Level: **34**
*   Install Location: **Auto**
*   Default Orientation: **Landscape**
*   Signed release build
*   Built as **APK** (AAB not recommended for Quest)
    

🔧 Setup
--------
1.  Download and extract ovr-platform-util.exe
2.  Place it in a fixed directory
    

▶️ Usage
--------
1.  Launch the application
2.  Enter:
    *   App ID
    *   App Secret
    *   Select CLI Path
3.  Select your APK
4.  Choose release channel    
5.  Click **Deploy**

Logs stream live from the Meta CLI.Successful upload returns exit code 0.


🔐 Security Notes
-----------------
*   Tokens are not stored
*   No secrets are hardcoded
*   Uses official Meta CLI for all uploads
*   Local machine only (no remote service)
    

🧱 Project Structure
--------------------
`   MetaQuestDeployer/   ├── MainWindow.xaml   ├── MainWindow.xaml.cs   ├── MetaQuestDeployer.csproj   `

Minimal architecture by design.

🚧 Known Limitations
--------------------
*   Supports APK only
*   No automatic version detection
*   No encrypted AppId or AppSecret storage    
*   Single-app workflow
*   No CI integration
    

🛣 Future Improvements
----------------------
*   Windows DPAPI encrypted token storage
*   Drag & drop support
*   Version auto-detection from APK
*   Upload progress indicator
*   Multiple app profiles
*   CI/CD mode
    

📄 License
----------
MIT
