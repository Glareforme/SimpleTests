package Hooks;

import io.cucumber.java.*;
import io.cucumber.java.AfterAll;

public class UIHooks {
    @Before("@uiFeature")
    public void  BeforeUIFeature(){
        System.out.println("Before feature");
    }

    @After("@uiFeature")
    public  void  AfterUITest(){

    }

    @AfterAll
    public static void  AfterUITests(){
        System.out.println("After tests");
    }
}
