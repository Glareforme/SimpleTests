package POM.Locators;

import org.openqa.selenium.By;

public class LoginPageLocators {
    public static By UsernameField = By.cssSelector("#user-name");
    public static By PasswordFiled = By.cssSelector("#password");
    public static By SubmitButton = By.cssSelector("#login-button");
    public static By ExceptionMessage = By.cssSelector("div .error-message-container h3");
}
