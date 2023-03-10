package helper;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.NoSuchWindowException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

import java.io.FileInputStream;
import java.util.Properties;
import java.util.Set;
import java.util.concurrent.TimeUnit;

public class BrowserHelper {
    public static WebDriver webDriver;
    public static Properties prop;

    public BrowserHelper(){
        try {
            prop = new Properties();
            FileInputStream path = new FileInputStream("path");

            prop.load(path);
        } catch (Exception e) {
            // TODO: handle exception
        }
    }

    public static void initializationDriver(){
        WebDriverManager.chromedriver().setup();

        webDriver = new ChromeDriver();
        webDriver.manage().deleteAllCookies();
        webDriver.manage().window().maximize();
        webDriver.get(prop.getProperty("url"));
        webDriver.manage().timeouts().implicitlyWait(3, TimeUnit.SECONDS);
    }

    public static void switchWindow() throws NoSuchWindowException {
        Set<String> handles = webDriver.getWindowHandles();
        String current = webDriver.getWindowHandle();
        if (handles.size() > 1) {
            handles.remove(current);
        }
        String newTab = handles.iterator().next();
        webDriver.switchTo().window(newTab);
    }

    public static void disableBrowser () {
        webDriver.quit();
    }
}

