# LLM-Zero-Prompt for .NET (There is also a Python version on the say in the coming days)

LLM-Zero-Prompt for .NET is a code-first library designed for seamless interaction with large language models, such as OpenAI. This library addresses the inherent fragility of traditional prompting methods in large language models. Handcrafted prompts often need to be more effective when models change, primarily due to model drift.

## Overview

At Open Agentic, our team developed LLM-Zero-Prompt as an integral part of our Open Agentic Commander Platform. We aimed to mitigate the issues associated with prompt brittleness and model drift. We achieved this by incorporating the library and optimized prompt packs tailored for specific large language models. These prompt packs are model-specific and integrated into the connectors used to interface with the models. Switching models or connector families requires loading and utilizing a new optimized prompt pack.

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
