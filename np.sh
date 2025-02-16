#!/bin/zsh

# Définir le chemin du fichier contenant la clé API
API_KEY_FILE="./session.2017"

# Vérifier si le fichier existe
if [[ -f "$API_KEY_FILE" ]]; then
    # Lire le contenu du fichier et stocker la valeur dans une variable
    API_KEY=$(<"$API_KEY_FILE")

    # Afficher la clé (facultatif, attention à ne pas afficher des clés sensibles en production)
    # echo "Clé API lue: $API_KEY"
else
    echo "Erreur : Le fichier $API_KEY_FILE n'existe pas."
    exit 1
fi

if [[ -d "$1" ]]; then
    echo "Le répertoire $1 existe."
    exit 1
else
    echo "Le répertoire $1 n'existe pas."
    mkdir -p $1
    cd $1
    dotnet new console
    dotnet new sln
    dotnet sln add "$1.csproj"
    cp ../Program.cs .
    touch test.txt
    p=$(($1))
    echo " p : $p"
    curl -l "https://adventofcode.com/2017/day/$p/input" --cookie "session=$API_KEY" -o data.txt
    # go_to_dir $1
fi

