import { describe, test, expect } from "vitest";

import { some } from "./some";

describe("some", () => {
  test("return false if empty array", () => {
    //Arrange
    let array = [];

    //Act
    let result = some(array, e => true);

    //Assert
    expect(result).toBe(false);
  });

  test("return false if no element comply", () => {
    //Arrange
    let array = [1, 2, 3, 4, 5];

    //Act
    let result = some(array, e => e > 5);

    //Assert
    expect(result).toBe(false);
  });

  test("return true if at least 1 element comply", () => {
    //Arrange
    let array = [1, 2, 3, 4, 5];

    //Act
    let result = some(array, e => e % 2 == 0);

    //Assert
    expect(result).toBe(true);
  });
});
