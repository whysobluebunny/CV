package in.reqres.bondarenko.hw;

import dto.*;
import org.junit.jupiter.api.BeforeEach;

import org.junit.jupiter.api.Test;
import steps.Steps;

import static io.restassured.RestAssured.given;

public class Tests {
    Steps steps;

    @BeforeEach
    public void beforeEach() {
        steps = new Steps();
    }

    @Test
    public void firstTest(){
        Specification.installSpec(Specification.requestSpec(),Specification.responseSpec(200));
        PaintData paintData = given()
                .when()
                .get("https://reqres.in/api/unknown")
                .then()
                .statusCode(200)
                .extract().as(PaintData.class);

        steps.checkColors(paintData);
        steps.checkNumOfResources(paintData);
        steps.checkIfContainsYear(paintData, 2001);
    }

    @Test
    public void secondTest(){
        UserLogin newUser = new UserLogin("janet.weaver@reqres.in", "verymuchpassword");
        Specification.installSpec(Specification.requestSpec(),Specification.responseSpec(200));
        RegisterInfo info = given()
                .body(newUser)
                .when()
                .post("https://reqres.in/api/register")
                .then()
                .log().body()
                .extract().as(RegisterInfo.class);

        UserRequest user = given()
                .when()
                .get("https://reqres.in/api/users/" + info.getId())
                .then()
                .log().body()
                .extract().as(UserRequest.class);

        Specification.installSpec(Specification.responseSpec(204));
        given()
                .when()
                .delete("https://reqres.in/api/users/" + info.getId());

    }

    @Test
    public void thirdTest(){
        given()
                .body("{\"email\": \"janet.weaver@reqres.in\"}")
                .when()
                .post("https://reqres.in/api/register")
                .then()
                .log().body()
                .statusCode(400);
    }
}
