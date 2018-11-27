import { entries } from "./entries";

describe("entries", () => {
    test("should return an array filled with array of attributes and value of the passed object", () => {
        //Arrange
        let object = {
            a: "somestring",
            b: 42,
            c: false
        };

        //Act
        let result = entries(object);

        //Assert
        expect(result).toEqual([["a", "somestring"], ["b", 42], ["c", false]]);
    });

    test("should return an empty array if the passed object is empty", () => {
        //Arrange
        let object = {};

        //Act
        let result = entries(object);

        //Assert
        expect(result).toEqual([]);
    });
});
