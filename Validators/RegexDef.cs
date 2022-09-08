namespace frich.Validators;

internal class RegexDef
{
    /*
         ^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$
     └─────┬────┘└───┬──┘└─────┬─────┘└─────┬─────┘ └───┬───┘
           │         │         │            │           no _ or . at the end
           │         │         │            │
           │         │         │            allowed characters
           │         │         │
           │         │         no __ or _. or ._ or .. inside
           │         │
           │         no _ or . at the beginning
           │
           username is 8-20 characters long
     */
    public static string UsernameRegex = "^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$";
    
    // Minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character:
    public static string PasswordRegex = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$";
    
    public static string EmailRegex = "\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\b";

}
