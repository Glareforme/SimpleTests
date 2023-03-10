package StepDefination;

import io.cucumber.datatable.DataTable;
import io.cucumber.java.en.*;

public class UISStepDefinition {
    @Given("^the user enters valid credentials$")
    public void the_user_enters_valid_credentials(DataTable dataTable) {
        System.out.println("Step 1");
    }
    @Then("^the product page is displayed$")
    public void verify_user_on_welcome_page() {
        System.out.println("Step 2");
    }
}