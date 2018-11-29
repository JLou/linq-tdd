import { forEach } from "./foreach";

describe("foreach", () => {
  test("empty array should not execute the callback", () => {
    //Arrange
    let array = [];

    //Act
    forEach(array, () => fail());

    //Assert
    //Did not fail
  });

  test("should iterate each value", () => {
    //Arrange
    let array = [1, undefined, "toto", {}];
    let newArray = [];
    //Act
    forEach(array, val => newArray.push(val));

    //Assert
    expect(newArray).toEqual(array);
  });

  test("Should provide index, starting at 0", () => {
    //Arrange
    let array = [1, undefined, "toto", {}];
    let idxArray = [];

    //Act
    forEach(array, (val, idx) => idxArray.push(idx));

    //Assert
    expect(idxArray).toEqual([0, 1, 2, 3]);
  });

  test("Should have correct index and value", () => {
    //Arrange
    let array = [1, undefined, "toto", {}];
    let idxArray = [];

    //Act
    forEach(array, (val, idx) => idxArray.push([val, idx]));

    //Assert
    expect(idxArray).toEqual([[1, 0], [undefined, 1], ["toto", 2], [{}, 3]]);
  });
});
