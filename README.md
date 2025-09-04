# Checkpoint 1 - C# (2° Semestre)

## Processamento Assíncrono de Arquivos TXT

### ❔Descrição
Este projeto é uma aplicação **Console em C#** que permite ao usuário selecionar arquivos `.txt` de uma pasta e processá-los de forma **assíncrona** e **paralela**, contando a quantidade de **linhas** e **palavras** em cada arquivo.  
O resultado consolidado é salvo em `./export/relatorio.txt`.

---

## 🚀Funcionalidades
- Solicita ao usuário um diretório no computador.
- Busca todos os arquivos `.txt` encontrados nesse diretório.
- Lista os arquivos localizados na tela.
- Processa cada arquivo **em paralelo** utilizando `async/await`.
- Conta o número de linhas e de palavras de cada arquivo.
