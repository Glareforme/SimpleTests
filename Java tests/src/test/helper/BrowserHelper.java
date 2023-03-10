package helper;

import io.github.bonigarcia.wdm.WebDriverManager;
import org.openqa.selenium.NoSuchWindowException;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import java.io.FileInputStream;
import java.io.IOException;
import java.time.Duration;
import java.util.Properties;
import java.util.Set;

public class BrowserHelper {
    public static WebDriver webDriver;
    public static Properties prop;

    public BrowserHelper() throws Exception {
        try {
            prop = new Properties();
            FileInputStream path = new FileInputStream("src/config.properties");
            prop.load(path);
        } catch (IOException e) {
            throw new IOException(e);
        }
    }

    public static WebDriver initializationDriver(){
        WebDriverManager.chromedriver().setup();

        webDriver = new ChromeDriver();
        webDriver.manage().deleteAllCookies();
        webDriver.manage().window().maximize();
        webDriver.manage().timeouts().implicitlyWait(Duration.ofSeconds(10));

        return webDriver;
    }

    public static WebDriver GetBrowser(){
        return  webDriver == null ? initializationDriver() : webDriver;
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

