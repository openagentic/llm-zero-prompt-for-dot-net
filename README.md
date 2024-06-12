![enter image description here](https://openagenticpublicstorage.blob.core.windows.net/public/LLM-Zero-Prompt.jpg)

# About LLM-Zero-Prompt for .NET 
LLM-Zero-Prompt for .NET is a code-first library designed for seamless interaction with large language models,
such as OpenAI. This library addresses the inherent fragility of traditional prompting methods in large language models.
Handcrafted prompts often must be more effective when models change, primarily due to model drift.
LLM-Zero-Prompt addresses these issues by providing a library that focuses on providing the developer with a coding experience,
not a prompting experience; this is achieved by providing the developer with native LLM actions that can be invoked behind the scenes.
The library uses a set of prompt optimizers and prompt optimization packs that do all the heavy lifting. 
Each LLM connector has its prompt optimization packs. Changing the model or connector means that a new optimization pack is used to suit that type of connector and model.
The enormous advantage is that changing models means you do not have to modify your prompts, 
also model drift is taken care of with updates to the optimization packs, something Open Agentic will add shortly. 
You can download and update prompt optimization packs for LLM models.

At Open Agentic Labs, our team developed LLM-Zero-Prompt as an integral part of our Open Agentic Commander Platform. 
We aimed to mitigate the issues associated with prompt brittleness and model drift. 
We achieved this by incorporating the library and optimized prompt packs tailored for specific large language models. 
These prompt packs are model-specific and integrated into the connectors used to interface with the models. 
Switching models or connector families requires loading and utilizing a new optimized prompt pack.


## Wiki Pages 
The Wiki pages for this project is located here: https://bit.ly/3Xiqv88

## Git Repository
The GITHub repository for this project is located here: https://bit.ly/3KD3yoL

## Getting Started with Visual Studio 2022 (Using Clone Of GitHub Repository)

1. **Clone the Repository**
   - Clone the repository to your local machine using your preferred method (e.g., Git CLI, GitHub Desktop).

2. **Open the Solution**
   - Open the cloned solution in Visual Studio 2022.

3. **Set the Start-up Project**
   - Ensure the `OpenAgenticLabs.LLMZeroPrompt` project is set as the start-up project. To do this, right-click on the project in the Visual Studio 2022 Solution Explorer and select `Set as StartUp Project`.

4. **Set the OpenAI API Key**
   - Expand the `OpenAgenticLabs.LLMZeroPrompt` project by clicking the triangle to the left of the project name.
   - Double-click on `appsettings.json` to open it in the code window.
   - Add your OpenAI API key to the JSON file.

5. **Run the Project**
   - Press `F5` to run the project. The `OpenAgenticLabs.LLMZeroPrompt` application will start running.

	- 
## Getting Started with Visual Studio Code (Using Clone Of GitHub Repository)

1. **Clone the Repository**
   - Clone the repository to your local machine using your preferred method (e.g., Git CLI, GitHub Desktop).

2. **Open the Repository in VS Code**
   - Launch Visual Studio Code.
   - Open the cloned repository folder in VS Code by selecting `File` > `Open Folder...` and navigating to the repository's location.

3. **Install Required Extensions**
   - Ensure you have the necessary extensions installed. For a .NET project, you typically need the C# extension. You can install it from the Extensions view (`Ctrl+Shift+X`) by searching for "C#".

4. **Set Up the Project**
   - If the project uses a `launch.json` file for configuration, ensure it's correctly set up in the `.vscode` directory. VS Code should prompt you to add necessary assets for building and debugging if they are missing.

5. **Set the OpenAI API Key**
   - In the Explorer view, expand the `OpenAgenticLabs.LLMZeroPrompt` project directory.
   - Locate and double-click on the `appsettings.json` file to open it.
   - Add your OpenAI API key to the JSON file.

6. **Run the Project**
   - Open the Run and Debug view by clicking on the play icon in the sidebar or pressing `Ctrl+Shift+D`.
   - Select the appropriate configuration from the dropdown at the top.
   - Click the green play button or press `F5` to start debugging. The `OpenAgenticLabs.LLMZeroPrompt` application will start running.

7. **Optional: Configure Task Runners**
   - You can set up tasks to automate build and run commands. Create a `tasks.json` file in the `.vscode` directory with the desired configurations.

By following these steps, you can get started with the `OpenAgenticLabs.LLMZeroPrompt` project in Visual Studio Code.


## Python Version
There is also a Python version of this library from the team at Open Agentic Labs.
The python version is located here: https://bit.ly/3VCu0Fd


## How to Get an API Key from OpenAI

To access the powerful capabilities of OpenAI's services, you need to obtain an API key. This key allows you to authenticate your requests and use the various AI models and services offered by OpenAI. Here are the step-by-step instructions on how to get an API key from OpenAI:

### Step 1: Create an OpenAI Account
1. **Visit the OpenAI website**: Go to [OpenAI's official website](https://www.openai.com/).

2. **Sign up or log in**: If you don’t already have an account, click on the "Sign Up" button to create a new account. If you already have an account, simply log in using your credentials.

### Step 2: Navigate to the API Section
1. **Access your dashboard**: Once logged in, you will be directed to your account dashboard.
2. **Find the API section**: Look for a menu item or link labeled "API" or "API Keys". This is usually found in the main navigation menu or under your account settings.

### Step 3: Create a New API Key
1. **Generate a new key**: In the API section, there should be an option to generate a new API key. Click on the button or link that says "Create API Key" or "Generate New Key".
2. **Label your key**: Optionally, you might be prompted to label your key for organizational purposes. This can be useful if you plan to use multiple keys for different projects or applications.

### Step 4: Save Your API Key
1. **Copy the key**: Once generated, your new API key will be displayed. Make sure to copy it immediately.
2. **Store securely**: Save your API key in a secure location. Treat it like a password – do not share it publicly or expose it in your code repositories.

### Step 5: Use Your API Key
1. **Authenticate your requests**: Open the 'appsettings.json' file in the 'OpenAgenticLabs.LLMZeroPrompt' and replace the "<Put you OpenAI Key Here>" with your OpenAI key.
