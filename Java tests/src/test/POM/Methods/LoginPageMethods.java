package POM.Methods;

import POM.Locators.LoginPageLocators;
import helper.BrowserHelper;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.PageFactory;

public class LoginPageMethods{
    WebDriver driver;
    public LoginPageMethods() {
    driver = BrowserHelper.GetBrowser();
        PageFactory.initElements(driver, this);
    }

    public void InputLoginInField(String userLogin){
        driver.findElement(LoginPageLocators.UsernameField).sendKeys(userLogin);
    }

    public void InputPasswordField(String userPassword){
        driver.findElement(LoginPageLocators.PasswordFiled).sendKeys(userPassword);
    }

    public  void ClickSubmitButton(){
        driver.findElement(LoginPageLocators.SubmitButton).click();
    }
}
