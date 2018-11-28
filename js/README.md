# DOJO Réécrire les bases - JS

## Pricipe

Dans ce dojo vous allez implémenter des fonctions de bases du langage vous-même. Pour cela des stubs de fonctions vous sont fournis vous n'aurez qu'a écrire le code dedans pour répondre aux spécifications. Une batterie de tests unitaires vous permettra de vérifier que votre code fonctionne.

## Prérequis - Outils

- Un éditeur, je recommende vs code
- npm ou yarn fonctionnel

## Tester son code

Pour lancer les tests en mode watch, lancez la commande :

```bash
yarn/npm test -- --watch
```

Jest va vous proposer plusieurs options :

```
Press `a` to run all tests, or run Jest with `--watchAll`.

Watch Usage
 › Press a to run all tests.
 › Press f to run only failed tests.
 › Press p to filter by a filename regex pattern.
 › Press t to filter by a test name regex pattern.
 › Press q to quit watch mode.
 › Press Enter to trigger a test run.
```

Vu que vous n'allez travailler que sur une méthode a la fois, je vous conseille de faire `p` puis de taper le nom de la fonction que vous êtes en train d'écrire.
Exemple :

```
Pattern Mode Usage
 › Press Esc to exit pattern mode.
 › Press Enter to filter by a filenames regex pattern.

 pattern › every
```

Cela ne jouera que les tests pour `every`.

> Rappel : le but est de lancer les tests AVANT d'écrire son code
