package Models;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor

public class CredentialsModel {

    private String login;
    private String password;

    /*public String getLogin() {
        return Login;
    }
    // Setter
    public void setName(String newLogin) {
        this.Login = newLogin;
    }

    public String getPassword() {
        return Password;
    }
    // Setter
    public void setPassword(String newPassword) {
        this.Password = newPassword;
    }*/
}
