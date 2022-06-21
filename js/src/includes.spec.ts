import { includes } from "./includes";

describe("includes", () => {
  let trueCases : [any[], any][] = [
    [[1, 2, 3], 3],
    [["a", "b", "c"], "b"],
    [[1, 2, NaN], NaN],
    [[undefined, "a", 15], undefined],
    [[null, 55, "azeaze"], null],
    [[1.55, 3.58, 1.33], 1.55]
  ];
  test.each(trueCases)("%p includes %p", (arr, searchElement) => {
    //Act
    let result = includes(arr, searchElement);

    //Assert
    expect(result).toBe(true);
  });

  let falseCases : [any[], any][] = [
    [[], 3],
    [["a", "b", "c"], "d"],
    [[1, 2, NaN], 4],
    [[undefined, "a", 15], null],
    [[null, 55, "azeaze"], undefined]
  ] ;

  test.each(falseCases)("%p does not includes %p", (arr, searchElement) => {
    //Act
    let result = includes(arr, searchElement);

    //Assert
    expect(result).toBe(false);
  });
});
