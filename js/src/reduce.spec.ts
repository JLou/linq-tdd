import { reduce } from "./reduce";

describe("reduce", () => {
  test("empty array returns initial accumulator value", () => {
    //Arrange
    let array = [];

    //Act
    let result = reduce(array, () => 1, 10);

    //Assert
    expect(result).toBe(10);
  });

  test("only using accumulator value", () => {
    //Arrange
    let array = [1, 2, 3];

    //Act
    let result = reduce(array, acc => acc + 1, 0);

    //Assert
    expect(result).toBe(3);
  });

  test("using accumulator value and current element", () => {
    //Arrange
    let array = [1, 2, 3];

    //Act
    let result = reduce(array, (acc, el) => acc + el, 0);

    //Assert
    expect(result).toBe(6);
  });

  test("using accumulator value and current element and index", () => {
    //Arrange
    // attention l'index commence a 1
    let array = [5, 10, 1];

    //Act
    let result = reduce(array, (acc, el, idx) => acc + el * idx, 0);

    //Assert
    expect(result).toBe(28);
  });

  test("using accumulator value, current element, index and initial value", () => {
    //Arrange
    // attention l'index commence a 1
    let array = [5, 10, 1];

    //Act
    let result = reduce(array, (acc, el, idx) => acc + el * idx, 50);

    //Assert
    expect(result).toBe(78);
  });

  test("using non numeral values", () => {
    //Arrange
    let array = ["cat", "dog", "octopus"];

    //Act
    let result = reduce(array, (acc, el, idx) => `${acc} #${idx}-${el}`, "");

    //Assert
    expect(result).toBe(" #1-cat #2-dog #3-octopus");
  });

  test("transforming text into number", () => {
    //Arrange
    let array = ["cat", "dog", "octopus"];

    //Act
    let result = reduce(array, (acc, el, idx) => acc + el.length, 0);

    //Assert
    expect(result).toBe(13);
  });
});
