import { values } from "./values";

describe("values", () => {
    test("should return an array filled with the attributes of the passed object", () => {
        //Arrange
        let object = {
            a: "somestring",
            b: 42,
            c: false
        };

        //Act
        let result = values(object);

        //Assert
        expect(result).toEqual(["somestring", 42, false]);
    });

    test("should return an empty array if the passed object is empty", () => {
        //Arrange
        let object = {};

        //Act
        let result = values(object);

        //Assert
        expect(result).toEqual([]);
    });
});
