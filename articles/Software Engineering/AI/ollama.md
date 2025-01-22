
https://ollama.com

Install WSL `wsl --install` (setup admin credentials)

Run Linux on Windows 
`wsl`

Update Ubuntu (admin credentials needed)
`sudo apt update`
`sudo apt upgrade -y`

Install Ollama
`curl -fsSL https://ollama.com/install.sh | sh`

Run Ollama
`ollama serve`

Check if Ollama is properly installed
http://localhost:11434

Pull LLM
`ollama pull llama2`

Run LLM
`ollama run llama2`


Run Open WebUI

`docker run -d -p 3000:8080 -e OLLAMA_BASE_URL=http://localhost:11434 -v open-webui:/app/backend/data --name open-webui --restart always ghcr.io/open-webui/open-webui:main`