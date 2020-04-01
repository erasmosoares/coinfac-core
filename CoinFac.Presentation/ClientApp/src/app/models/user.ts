export class User implements IUser{
    
    id: string;
    givenName: string;
    familyName: string;
    name: string;
    pictureUrl: string;
    locale: string;
    updatedAt: string;
    email: string;
    emailVerified: string;
    sub: string;
}

interface IUser{
    id: string,
    givenName: string,
    familyName: string,
    name: string,
    pictureUrl: string,
    locale: string,
    updatedAt: string,
    email: string,
    emailVerified: string,
    sub: string
}