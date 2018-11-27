import { keys } from "./keys";

describe("keys", () => {
    test("should return an array filled with the attributes of the passed object", () => {
        //Arrange
        let object = {
            a: "somestring",
            b: 42,
            c: false
        };

        //Act
        let result = keys(object);

        //Assert
        expect(result).toEqual(["a", "b", "c"]);
    });

    test("should return an empty array if the passed object is empty", () => {
        //Arrange
        let object = {};

        //Act
        let result = keys(object);

        //Assert
        expect(result).toEqual([]);
    });
});
