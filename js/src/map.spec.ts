import { map } from "./map";
describe("map", () => {
  test("[map] apply function", () => {
    //Arrange
    let arr = [1, 2, 3];
    let fn = n => n * n;

    //Act
    let result = map(arr, fn);

    //Assert
    expect(result).toEqual(expect.arrayContaining([1, 4, 9]));
  });

  test("[map] empty array", () => {
    //Arrange
    let arr = [];
    let fn = n => n * n;

    //Act
    let result = map(arr, fn);

    //Assert
    expect(result).toEqual([]);
  });

  test("[map] type change", () => {
    //Arrange
    let arr = ["1", "2", "3"];
    let fn = n => Number(n);

    //Act
    let result = map(arr, fn);

    //Assert
    expect(result).toEqual(expect.arrayContaining([1, 2, 3]));
  });
});
