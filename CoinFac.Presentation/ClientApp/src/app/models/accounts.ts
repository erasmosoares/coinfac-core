import { Record } from "./record";

export class Account implements IAccount {
    id: string;
    name: string;
    goal: string;
    accountType: string;
    comments: string;
    userId: string;
    records: Record[];
}

interface IAccount {

    id: string;
    name: string;
    goal: string;
    accountType: string;
    comments: string;
    userId: string;
    records: Record[];
}