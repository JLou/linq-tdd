import { every } from "./every";

describe("every", () => {
  test("should return true when all elements comply", () => {
    //Arrange
    let array = [12, 54, 18, 130, 44];

    //Act
    let result = every(array, x => x >= 10);

    //Assert
    expect(result).toBe(true);
  });

  test("should return true when empty array", () => {
    //Act
    let result = every([], x => false);

    //Assert
    expect(result).toBe(true);
  });

  test("should return false when at least one element does not comply", () => {
    //Arrange
    let array = [12, 54, 18, 130, 44];

    //Act
    let result = every(array, x => x <= 10);

    //Assert
    expect(result).toBe(false);
  });
});
