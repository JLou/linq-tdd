# DOJO Réécrire les bases - C

## Principe

Dans ce dojo le but sera de manipuler les Enumerator C# pour réécrire quelques fonctions LINQ.
Pour cela, des stubs de fonctions vous sont fournis, vous n'aurez qu'a écrire le code dedans pour répondre aux spécifications.
Une batterie de tests unitaires vous permettra de vérifier que votre code fonctionne.

## Prérequis - Outils

- [VS Code](https://code.visualstudio.com/)
  - Plugin [C#](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
  - Plugin [.NET Core Test Explorer](https://marketplace.visualstudio.com/items?itemName=formulahendry.dotnet-test-explorer)
- [SDK .NET Core](https://dotnet.microsoft.com/download)

## Rappel sur les énumerateurs

L'interface `IEnumerable<T>` fournit une méthode `GetEnumerator()` qui vous retourne un `IEnumerator<T>`. Cet Enumerator vous permet de parcourir les élements dans l'énumérable via 2 méthodes :

```csharp
public bool MoveNext()
```

MoveNext avance l'énumerator au prochain item dans l'énumerable. Retourne true si il a réussi a avancer dans l'énumerable, false si il n'y a plus d'éléments a parcourir.

> A l'initialisation, vous n'êtes pas encore sur un élément. Pour accéder au premier élement vous devez faire un `MoveNext()`

```csharp
public T Current { get; }
```

Current est une propriété qui vous retourne l'élement courant.

Pour parcourir un `IEnumerable<T>`, il faut donc écrire :

```csharp
IEnumerable<int> squares = Enumerable.Range(1, 10);
IEnumerator<int> enumerator = squares.GetEnumerator();

while(enumerator.MoveNext())
{
    int item = enumerator.Current;
    Console.WriteLine(item);
}
```

### yield return

Rappel : on utilise le `yield return` pour retourner les élement un par un. Cela permet de générer une énumération au fur et à mesure.
Exemple :

```csharp
public class PowersOf2
{
    static void Main()
    {
        // Affiche les puissances de 2 jusque l'exposant 8 :
        foreach (int i in Power(2, 8))
        {
            Console.Write("{0} ", i);
        }
    }

    public static IEnumerable<int> Power(int number, int exponent)
    {
        int result = 1;

        for (int i = 0; i < exponent; i++)
        {
            result = result * number;
            yield return result;
        }
    }

    // Output: 2 4 8 16 32 64 128 256
}
```

## Règles

Le but du jeu étant de jouer avec les Enumerators, il est interdit d'utiliser les boucles `foreach`. Idéalement vous devez réussir a réécrire les fonctions avec uniquement les Enumerators, des boucles `while` et des `yield return`.
Les méthodes a réécrire sont suffixées de _2_ pour ne pas rentrer en conflit avec les méthodes Linq du framework.

## A vous de jouer !

### 1. FirstOrDefault2

Cette méthode retourne le premier élement de l'énumération. Si aucun élément n'est présent, retourne la valeur par defaut pour le type `T` (il existe un mot clé pour retourner la valeur par défaut d'un type).

### 2. Select2

```csharp
public static IEnumerable<TResult> Select2<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
```

Select est une projection. Cela permet de transformer chacun des élements d'une énumeration via une méthode appelée `selector`.

### 3. Where2

```csharp
public static IEnumerable<TSource> Where2<TSource>(
    this IEnumerable<TSource> source,
    Func<TSource, bool> predicate)
```

Cette méthode retourne l'ensemble des élements de l'énumération qui répondent a une condition, exprimée sous forme de fonction nommée `predicate`.

### 4. SelectMany2

```csharp
public static IEnumerable<TResult> SelectMany2<TSource, TResult>(
    this IEnumerable<TSource> source,
    Func<TSource, IEnumerable<TResult>> selector)
```

SelectMany permet d'applatir des enumerations imbriquées. Le `selector` a appliquer a l'enumeration va retourner une enumeration lui meme. Le but étant d'avoir en sortie une unique énumeration qui est la concaténation de toutes les sous énumerations.
Exemple:

```csharp
new dynamic[] {
    new { item = [1,2,3] },
    new { item = [4,5,6]}
}.SelectMany(e => e.item);
// devient [1,2,3,4,5,6]
```

### 5. Aggregate2

```csharp
public static TResult Aggregate2<TSource, TAccumulate, TResult>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector)
```

On complique un peu les choses avec l'aggregate. Cette méthode applique une fonction d'accumulation `func` sur une séquence. La `seed` est la valeur initiale utilisé par l'accumulateur, et le selecteur `resultSelector` permet de transformer le resultat final de l'accumulation.
Exemple, on va chercher quel est le fruit avec le nom le plus long, puis retourner cette valeur en majuscule :

```csharp
string[] fruits = { "pomme", "mangue", "orange", "fruit de la passion", "raisin" };
string longestName =
    fruits.Aggregate2("banane",
    // garde la valeur du fruit le plus long au fur et a mesure
                    (longest, next) =>
                        next.Length > longest.Length ? next : longest,
    // retourne le resultat final en majuscules.
                    fruit => fruit.ToUpper());
```

Les valeurs successives que va prendre la valeur de l'accumulateur seront : `banane, banane, banane, banane, fruit de la passion, fruit de la passion`. Puis on applique la transformation : `FRUIT DE LA PASSION`.
