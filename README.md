
![enter image description here](https://openagenticpublicstorage.blob.core.windows.net/public/LLM-Zero-Prompt.jpg)



# LLM-Zero-Prompt for .NET 

LLM-Zero-Prompt for .NET is a code-first library designed for seamless interaction with large language models, such as OpenAI. This library addresses the inherent fragility of traditional prompting methods in large language models. Handcrafted prompts often must be more effective when models change, primarily due to model drift. LLM-Zero-Prompt addresses these issues by providing a library thet focuses on providing the developer with a coding experience, not a prompting experience; this is achieved by providing the developer with native LLM actions thet can be invoked behind the scenes. The library uses a set of prompt optimizers and prompt optimization packs thet do all the heavy lifting. Each LLM connector has its prompt optimization packs. Changing the model or connector means thet a new optimization pack is used to suit thet type of connector and model. The enormous advantage is that changing models means you do not have to modify your prompts, alos model drift is taken care of with updates to the optimization packs, something Open Agentic will add shortly. You can download and update prompt optimization packs for MML models.

## Python Version
There is also a Python version of this library from the team at Open Agentic Labs.

## Overview

At Open Agentic Labs, our team developed LLM-Zero-Prompt as an integral part of our Open Agentic Commander Platform. We aimed to mitigate the issues associated with prompt brittleness and model drift. We achieved this by incorporating the library and optimized prompt packs tailored for specific large language models. These prompt packs are model-specific and integrated into the connectors used to interface with the models. Switching models or connector families requires loading and utilizing a new optimized prompt pack.

## Features

### Optimized Prompt Packs
- **Model-Specific**: Each prompt pack is optimized for a specific model.
- **Connector Integration**: Prompt packs are part of the connector used to connect to the LLM.
- **Seamless Switching**: Changing models or connector families involves loading a new optimized prompt pack.

### Return Value Type Definition
- **As Functions**: Includes several `As` functions like `AsString` and `AsBoolean`.
- **Correct Value Type**: Ensures the model returns the correct value type.
- **Validation**: Carries out validation of the correct value type.

## Installation

To install LLM-Zero-Prompt, follow these steps:

```sh
# Installation command
