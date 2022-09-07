# DOJO Réécrire les bases - C&#35;

## Principe

Dans ce dojo le but sera de manipuler les Enumerator C# pour réécrire quelques fonctions LINQ.
Pour cela, des stubs de fonctions vous sont fournis, vous n'aurez qu'a écrire le code dedans pour répondre aux spécifications.
Une batterie de tests unitaires vous permettra de vérifier que votre code fonctionne.

## Prérequis - Outils

- .NET 6
- Un IDE capable d'afficher les résultats des tests
## Rappel sur les énumerateurs

L'interface `IEnumerable<T>` fournit une méthode `GetEnumerator()` qui vous retourne un `IEnumerator<T>`. Cet Enumerator vous permet de parcourir les elements dans l'énumérable via 2 méthodes :

```csharp
public bool MoveNext()
```

MoveNext avance l'énumerator au prochain item dans l'énumerable. Retourne `true` si il a réussi a avancer dans l'énumerable, `false` si il n'y a plus d'éléments a parcourir.

> A l'initialisation, vous n'êtes pas encore sur un élément. Pour accéder au premier élément vous devez faire un `MoveNext()`

```csharp
public T Current { get; }
```

Current est une propriété qui vous retourne l’élément courant.

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

Rappel : on utilise le `yield return` pour retourner les élément un par un. Cela permet de générer une énumération au fur et à mesure.
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

Le but du jeu étant de jouer avec les `Enumerator`s, il est interdit d'utiliser les boucles `foreach`. Idéalement vous devez réussir a réécrire les fonctions avec uniquement les `Enumerator`s, des boucles `while` et des `yield return`.
Les méthodes a réécrire sont suffixées de _2_ pour ne pas rentrer en conflit avec les méthodes Linq du framework.

## A vous de jouer !

### 1. FirstOrDefault2

Cette méthode retourne le premier élément de l'énumération. Si aucun élément n'est présent, retourne la valeur par défaut pour le type `T` (il existe un mot clé pour retourner la valeur par défaut d'un type).

### 2. Select2

```csharp
public static IEnumerable<TResult> Select2<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
```

Select est une projection. Cela permet de transformer chacun des éléments d'une énumération via une méthode appelée `selector`.

### 3. Where2

```csharp
public static IEnumerable<TSource> Where2<TSource>(
    this IEnumerable<TSource> source,
    Func<TSource, bool> predicate)
```

Cette méthode retourne l'ensemble des éléments de l'énumération qui répondent a une condition, exprimée sous forme de fonction nommée `predicate`.

### 4. SelectMany2

```csharp
public static IEnumerable<TResult> SelectMany2<TSource, TResult>(
    this IEnumerable<TSource> source,
    Func<TSource, IEnumerable<TResult>> selector)
```

SelectMany permet d’aplatir des énumérations imbriquées. Le `selector` a appliquer a l’énumération va retourner une énumération lui mème. Le but étant d'avoir en sortie une unique énumération qui est la concaténation de toutes les sous énumérations.
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

On complique un peu les choses avec l'aggregate. Cette méthode applique une fonction d'accumulation `func` sur une séquence. La `seed` est la valeur initiale utilisé par l'accumulateur, et le sélecteur `resultSelector` permet de transformer le résultat final de l'accumulation.
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

## Bonus

### 6. Zip

Si vous avez terminé, pouvez vous attaquer au Zip. Fonction méconnue qui permet de fusionner deux énumérations.

Pas d'aide ici, vous devriez être à l'aise maintenant. Voici la [documentation](https://docs.microsoft.com/fr-fr/dotnet/api/system.linq.enumerable.zip?view=net-6.0#exemples).

### 7. Any

La fonction `Any` permet 2 choses. Si aucun prédicat n'est passé, elle vérifie qu'au moins un élément est présent.
Si un prédicat est passé en paramètre, elle vérifie qu'au moins un élément répond au prédicat dans 
l'énumération.

Ex :
```csharp
string[] fruits = { "pomme", "mangue", "orange", "fruit de la passion", "raisin" };
string[] personnesQuiAimentLananasSurLaPizza = {};
fruits.Any(); // true
personnesQuiAimentLananasSurLaPizza.Any(); // false
fruits.Any(f => f.StartsWith("p")); // true, car pomme commence par p
fruits.Any(f => f == "tomate"); // false
```

### 8. All

La petite sœur de Any, permet de vérifier l'inverse : si tous les éléments de l'énumération
répondent au prédicat, elle retourne `true`. `false` si au moins un des éléments n'y répond pas.
On est obligé de lui passer un prédicat.
Ex :
```csharp
string[] fruits = { "pomme", "mangue", "orange", "fruit de la passion", "raisin" };
string[] personnesQuiAimentLananasSurLaPizza = {};
personnesQuiAimentLananasSurLaPizza.All(f => f.StartsWith("p")); // true, la collection est vide
fruits.All(f => f.StartsWith("p")); // false, car mangue ne commence pas  par p
fruits.All(f => f != "tomate"); // false
```

### 9. Skip

De façon assez prévisible, `Skip` prend un nombre entier `count`, et retourne l'énumération en
ignorant les `count` premiers éléments.

```csharp
int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

IEnumerable<int> lowerGrades =
    grades.OrderByDescending(g => g).Skip(3);

Console.WriteLine(string.Join(" ", lowerGrades)); // Affiche  82 70 59 56, ignore les 3 plus hautes valeurs
```

### 10. Take

La contrepartie de `Skip`, `Take` retourne un nombre spécifié d'éléments contigus à partir du début d'une séquence.

```csharp
int[] grades = { 59, 82, 70, 56, 92, 98, 85 };

IEnumerable<int> topThreeGrades =
    grades.OrderByDescending(grade => grade).Take(3);

Console.WriteLine(string.Join(" ", lowerGrades)); // Affiche  98 92 85, les 3 plus hautes valeurs
```

### 11. Reverse

Bon, ça inverse la séquence 🤷‍♀️.

```csharp
char[] apple = { 'a', 'p', 'p', 'l', 'e' };

char[] reversed = apple.Reverse().ToArray();

foreach (char chr in reversed)
{
    Console.Write(chr + " ");
}
Console.WriteLine();

/*
 This code produces the following output:

 e l p p a
*/
```