import { describe, test, expect } from "vitest";
import { filter } from "./filter";

describe("filter", () => {
  let trueCases: [any[], (value: any) => boolean, any][] = [
    [
      ["spray", "limit", "elite", "exuberant", "destruction", "present"],
      word => word.length > 6,
      ["exuberant", "destruction", "present"]
    ],
    [[12, 5, 8, 130, 44], n => n >= 10, [12, 130, 44]],
    [
      [
        { id: 15 },
        { id: -1 },
        { id: 0 },
        { id: 3 },
        { id: 12.2 },
        {},
        { id: null },
        { id: NaN },
        { id: "undefined" }
      ],
      item =>
        item.id !== undefined &&
        typeof item.id === "number" &&
        !isNaN(item.id) &&
        item.id !== 0,
      [{ id: 15 }, { id: -1 }, { id: 3 }, { id: 12.2 }]
    ]
  ];
  test.each(trueCases)(
    "Should filter correctly #%#",
    (originalArray, predicate, expectedArray) => {
      //Arrange

      //Act
      let result = filter(originalArray, predicate);

      //Assert
      expect(result).toEqual(expect.arrayContaining(expectedArray));
    }
  );

  test("Should return empty array when input is empty array", () => {
    //Arrange
    let originalArray = [];

    //Act
    let result = filter(originalArray, n => true);

    //Assert
    expect(result).toEqual(expect.arrayContaining([]));
  });

  test("Should return empty array when no element matches the predicate", () => {
    //Arrange
    let originalArray = ["a", 1, NaN, null, undefined];

    //Act
    let result = filter(originalArray, n => false);

    //Assert
    expect(result).toEqual(expect.arrayContaining([]));
  });
});
