- 1. Check if [[Build and Run a Container with Docker]] is installed by running ``docker version``
- 2. Install [[articles/Tools/VSCode]] and its extensions
- ```
  winget install -e --id Microsoft.VisualStudioCode  
  code --install-extension ms-vscode-remote.remote-containers  
  code --install-extension ms-python.python
  ```
- 3. Click ![image.png](../assets/image_1667341230993_0.png) located at the bottom left of the screen
  4. Search for "Add Dev Container Configuration Files" and follow the steps
  5. Once the setup is finished, the following 2 files will appear
- ![](data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAYEAAABBCAIAAAC4pI9zAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAUCSURBVHhe7d2xihxHEMbxkx/DCowCOTFKdIHAyBi/gMHgSDiQcWjQCxhHQi8gcCikwCgyGPwCxiCUSYlxLC6Q7hWszOWr3qKuZqa3p6d3ezT3/zEs1TXds6tgPnr37lbXbt789AQAenj//t+PUgkAPZBBAHoigwD0RAYB6Kl/Bn3964+pWoe1vR5g267cPmhvxPzx3S+pApD1yVefyZEGtXgvBmA2nz4Lk6gyg549e5qqgcwpI5sRPdJ4J/TDBD8czgwdobVvjnb8UPhT+ujPCu34ptahCaBE/e8oStbcv/99GuyMNgO9UfUtT6aeKkItwsKpOhTBcMLU8nwT2LypXc/Zn/+kqtii31GUrAlbnpIAUna7hvu25Da2O99bcsGM0eXlTQB7Lfo8yMdQeQBlSL7okcaHV/GMFUuALRnd71RsgtTSz6Q1hpoEkJDdhB3W0RveOg3pZf3TlbAls1YBGNXg52KSPiUB5DcOVvumCMMpw2lTFzyEIzwFsHKy67GNj68rNMiguXT7IHeyHH4r4fuZ+3w4zXdsmOFnaq3DEoUvErgKFqaP4rs7AHTDd3cA6IwMAtATGQSgJzIIQE9kEICeFmXQ6entVAFAFfZBAHoigwD0RAYB6IkMAtBT+wx6/vx6qi7XADDUOINC6Ny791Y6s5JobX8I2vD18Deu2JLPf/omVRfCsFz7fZDkTqouhOHa7M2FvX+FX67hpYDN4PMgAD2tIoNkM6JHGu+Efpjgh8OZoSO09s3Rjh8Kf0of/VmhHd/UOjRFmBMmWCc09dE3gS1pmUGZz30yp/Tukvcp+o1i2hTDvp8ghQx9rYcO5TEMlc20OfqohdVy+FUmLNeOPA6X2Mw0vszO2gR/HRsqm+ybwGasYh9kt6IVKgxH6S2aBjtLLpgxury8mWdLwtqKSwEfkJYZlPn4ue6TackXPdL48CqesWKJxMrcJcBWrfozablX7bCO3r3WaUgv65+uhC2pWEUM4YNmP4+v/sG8WMtn0qFQhbfocNrUBQ9h71PM/Vcc4TUDy7189Ls8SvpoAOmwQvsMCh8/7/0FRd0+yI0nh99K+H7mthxO8x0bZviZWuuwROGLDGy+vba5rxlYA8kdO1JrvkX/r8bp6e1Xr16nwY6Ezsp/L7EXHzoAxEH+Xw0CCEC5VX8mvRnhnRcA0/69GAAU4v84BNAZGQSgp2t37nyRyvlu3Lj+5g2fQAOodH5+xj4IQE9kEICeyCAAPZFBAHoigwD0dKgM+viHn1N1FHcff5uqmWShrrUrVF8KuFJuPfgyVRfCsFz/fZCmgB2pexTydC8e/CaH1PoI4MgaZ5Buf4aboPy2SINAjyPHEIC+WmZQPnqkzieRCjGkmyM9UmtntO87wwla+74v/p9xmZ4dPQWgiVV/Jq03v+6PbKik1r6eUjbf13JkFloxNHUFAA21ySC/xwmFnXr35KEcF2dmsIDwSaE5kgaX+f7onKmFo2ZNBlBh1fugWYbBJB090ni+5VcAkNcmg/wGZ3SzU74Dqr7hJYDCWunYkVozLb8CsGH28/jqH8yLlvsgfbdl78XM3ADyN7zFSsiXqajy/ak55ZZfAdiqvx//JY+SPhpAOqzQ8rs7QvoURk+4z8OOw58dzSYhfRnqWe37WlknXMSG/gq+qYXwCwE0cX5+xvcHAeiG7w8C0BkZBKAnMghAT2QQgJ7IIAD9nJz8BzSiZSQSJFpBAAAAAElFTkSuQmCC)
- 6. Click ![image.png](../assets/image_1667341230993_0.png) and write "Reopen in container"
  7. VSCode will restart and you will see this ![image.png](../assets/image_1667430653209_0.png)
# Training
- [Use a Docker container as a development environment with Visual Studio Code](https://learn.microsoft.com/en-us/training/modules/use-docker-container-dev-env-vs-code/)
- [Dev Containers tutorial](https://code.visualstudio.com/docs/devcontainers/tutorial)
- [Containers.dev](https://containers.dev/)
- [Templates](https://containers.dev/templates)
- https://code.visualstudio.com/docs/python/linting