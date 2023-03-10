package Hooks;

import helper.BrowserHelper;
import io.cucumber.java.*;
import io.cucumber.java.AfterAll;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

public class UIHooks {
    @Before("@uiFeature")
    public void  BeforeUIFeature() throws IOException {
        Properties prop = new Properties();
        FileInputStream path = new FileInputStream("src/config.properties");
        prop.load(path);

        BrowserHelper.GetBrowser().get(prop.getProperty("url"));
    }

    @After("@uiFeature")
    public  void  AfterUITest(){

    }

    @AfterAll
    public static void  AfterUITests(){
        BrowserHelper.disableBrowser();
    }
}
