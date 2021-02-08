export class User {
    id: number;
    isManager: boolean;
    ravkav: string;
    password: string;
    firstName: string;
    lastName: string;
    profileId: number;

    constructor(id: number,isManager: boolean,ravkav: string,password: string,firstName: string,lastName: string,profileId: number)
    {
        this .id=id;
        this.isManager=isManager;
        this.ravkav=ravkav;
        this.password=password;
        this.firstName=firstName;
        this.lastName=lastName;
        this.profileId=profileId;

    }
}
