package StepDefination;

import Models.CredentialsModel;
import POM.Methods.LoginPageMethods;
import dev.failsafe.internal.util.Assert;
import helper.BrowserHelper;
import io.cucumber.java.DataTableType;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import org.junit.jupiter.api.Assertions;

import java.util.List;
import java.util.Map;

public class UISStepDefinition {

    @DataTableType
    public CredentialsModel CredentialsTransformer(Map<String, String> row) {
        return new CredentialsModel(row.get("login"),
                row.get("password"));
    }

    LoginPageMethods loginPageMethods = new LoginPageMethods();

    @Given("^the user enters valid credentials$")
    public void the_user_enters_valid_credentials(List<CredentialsModel> dataTable) {
        loginPageMethods.InputLoginInField(dataTable.get(0).getLogin());
        loginPageMethods.InputPasswordField(dataTable.get(0).getPassword());
        loginPageMethods.ClickSubmitButton();
    }

    @Then("^the product page is displayed$")
    public void verify_user_on_welcome_page() {
        var currentUrl =  BrowserHelper.GetBrowser().getCurrentUrl();
        Assertions.assertEquals("https://www.saucedemo.com/inventory.html", currentUrl);
    }
}