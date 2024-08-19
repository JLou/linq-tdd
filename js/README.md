# DOJO Réécrire les bases - JS

## Pricipe

Dans ce dojo vous allez implémenter des fonctions de bases du langage vous-même.
Pour cela des stubs de fonctions vous sont fournis vous n'aurez qu'a écrire le
code dedans pour répondre aux spécifications. Une batterie de tests unitaires
vous permettra de vérifier que votre code fonctionne.

## Prérequis - Outils

- Un éditeur, je recommende vs code
- npm ou yarn ou pnpm fonctionnel
- Node v14.16.0 minimum

Le code est écrit en typescript. Cela ne devrait changer grand chose pour vous a
part l'autocomplétion et que l'ide ne sera pas content si vous ne retournez pas
le bon type.

Avant de démarrer, n'oubliez pas d'installer les modules node :

```bash
pnpm install
# ou
npm install
# ou
yarn install
```

## Tester son code

Pour lancer les tests en mode watch, lancez la commande :

```bash
pnpm test
yarn test
npm test
```

Vitest va vous proposer plusieurs options :

```
       press h to show help, press q to quit

  Watch Usage
  press a to rerun all tests
  press f to rerun only failed tests
  press u to update snapshot
  press t to filter by a test name regex pattern
  press q to quit
```

Vu que vous n'allez travailler que sur une méthode a la fois, je vous conseille
de faire `t` puis de taper le nom de la fonction que vous êtes en train
d'écrire. Exemple :

```
? Input test name pattern (RegExp) » every
```

Cela ne jouera que les tests pour `every`.

> Rappel : le but est de lancer les tests AVANT d'écrire son code

## Règles

Le but est d'implémenter ces fonctions, donc évidement utiliser la version
native pour résoudre le problème est interdit. Il faut jouer le jeu sinon ca ne
sert à rien. La plupart des fonctions peuvent être résolues juste avec une
boucle `for` classique. Essayez de vous y cantonner.

## A vous de jouer !

### 1. Includes

```ts
function includes(array: any[], searchElement: any): boolean;
```

Includes vérifie qu'un élement `searchElement` est bien présent dans le tableau
`array`. Retourne `true` si l'élement est présent, `false` sinon.

> Attention, il y a un test avec `NaN`, or en JS, `NaN !== NaN` il faut donc
> trouver l'astuce pour faire passer le test. Si ca vous prend plus de 2min,
> désactivez le test et revenez y plus tard.

### 2. Some

```typescript
function some<T>(array: T[], predicate: (value: T) => boolean): boolean;
```

Some vérifie qu'au moins un des élement du tableau `array` satisfait la
condition `predicate`. `predicate` est une fonction qui prend un élément du
tableau en entrée, et retourne un booléen disant si la condition est satisfaite
par l'élement.

Retourne `true` si au moins 1 élément satisfait la condition, `false` sinon. Si
le tableau est vide, retounez `false`.

### 3. Every

```ts
function every<T>(array: T[], predicate: (item: T) => boolean): boolean;
```

Every fonctionne comme le some, sauf qu'il vérifie que TOUT les élements du
tableau satisfont la condition.

Retourne `true` si tous les éléments satisfont la condition, `false` sinon. Si
le tableau est vide, retounez `true`.

### 4. ForEach

```ts
function forEach<T>(
  array: T[],
  callbackfn: (value: T, index: number) => void
): void;
```

Foreach itère sur chacun des élements du tableau `array`, et appelle la fonction
`callbackFn` avec l'élement courant et son index a chaque tour. Cette méthode ne
retourne rien.

### 5. Map

```ts
function map<TInput, TOuput>(
  array: TInput[],
  mapFn: (value: TInput) => TOuput
): TOuput[];
```

Map est une projection. On a en entrée un tableau de `TInput`: `array`, et une
fonction `callback` qui a en entrée un element de type `TInput` et en sortie un
element de type `TOuput`. On applique cette fonction a l'ensemble des élements
du tableau et on obtient un nouveau tableau de `TOuput`.

### 6. Filter

```ts
function filter<TInput>(
  array: TInput[],
  callbackFn: (value: TInput) => boolean
): TInput[];
```

Filter va, comme son nom l'indique filtrer les élements d'un tableau selon une
condition et retourner un nouveau tableau avec uniquement les élements qui
satisfont la condition `callbackFn`.

### 7. Reduce

```ts
function reduce<TInput, TOutput>(
  array: TInput[],
  reducerFn: (
    acc: TOutput,
    currentValue: TInput,
    currentIndex: number
  ) => TOutput,
  initialValue: TOutput
): TOutput;
```

Reduce applique une fonction d'accumulation a une séquence. On part d'une valeur
initiale pour l'accumulateur `initialValue`, et pour chacun des élements du
tableau `array`, on met a jour l'accumulateur avec la fonction `reducerFn`. Par
exemple, pour calculer la somme et le produit d'un tableau d'entier, on fait :

```js
reduce([1, 2, 3, 4], (acc, next) => acc + next, 0); // 10
reduce([1, 2, 3, 4], (acc, next) => acc * next, 1); // 24
```

## Les Objets

Vous êtes arrivés au bout des exercices sur les tableaux. En bonus, je vous
propose de passer a l'implémentation de fonctions sur les objets. Pour pouvoir
implémenter ces fonctions, il va falloir utiliser des boucles `for`, mais
légèrement différentes.

### 8. Keys

```ts
function keys(object: Object): string[];
```

Keys prend en entrée un objet, et retourne la liste des clés de l'objet. Exemple
:

```js
keys({ a: 1, b: console.log }); // retourne [a, b]
```

### 9. Values

```ts
function values(object: Object): any[];
```

Values fonctionne comme `keys`, sauf qu'il renvoit les valeurs de l'objet.
Exemple :

```ts
values({ a: 1, b: console.log }); // retourne [1, console.log]
```

### 10. Entries

```ts
function entries(object: Object): [string, any][];
```

Entries combine `keys` et `values`. Il retourne un tableau où chaque entrée est
un tableau à deux entrées, la première étant la clé, la seconde est la valeur
associé à la clé. Exemple :

```ts
entries({ a: 1, b: console.log }); // retourne [[a, 1], [b, console.log]]
```
