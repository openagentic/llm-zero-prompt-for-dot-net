import clr
import sys

sys.path.append(r'C:/5/OpenAgenticLabs.LLMZeroPrompt.Core/bin/Release/net8.0')
sys.path.append(r'C:/5/OpenAgenticLabs.LLMZeroPrompt.OpenAI/bin/Release/net8.0')
sys.path.append(r'C:/5/OpenAgenticLabs.LLMZeroPrompt.PythonHelper/bin/Release/net8.0')

clr.AddReference('OpenAgenticLabs.LLMZeroPrompt.Core')
clr.AddReference('OpenAgenticLabs.LLMZeroPrompt.OpenAI')
clr.AddReference('OpenAgenticLabs.LLMZeroPrompt.PythonHelper')

from OpenAgenticLabs.LLMZeroPrompt.PythonHelper import ZeroPromptFactory

instanceOfActionFactory = ZeroPromptFactory()

actionFactory = instanceOfActionFactory.Open()

print("hello world!!!")