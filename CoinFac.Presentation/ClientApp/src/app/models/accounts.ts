export class Accounts implements IAccount{
    id: string;
    name: string;
    goal: string;
    accountType: string;
    comments: string;
    userId: string;
}

interface IAccount{

    id: string;
    name: string;
    goal: string;
    accountType: string;
    comments: string;
    userId: string;
}