/*

RBC Royal Bank
Bank of Montreal
National Bank of Canada
Desjardins
HSBC


export var completeAccountsForTest = [
  {
    "id": 37,
    "name": "Neon",
    "goal": 1000,
    "accountType": 0,
    "comments": "BR account",
    "userId": 73,
    "records": [
      {
        "account": "Neon",
        "date": "2020-06-29T21:02:34.0642433",
        "amount": 156
      },
      {
        "account": "Neon",
        "date": "2020-06-29T21:07:46.9240505",
        "amount": 987
      },
      {
        "account": "Neon",
        "date": "2020-06-29T21:21:39.8841947",
        "amount": 156
      },
      {
        "account": "Neon",
        "date": "2020-06-29T22:02:04.1286773",
        "amount": 665
      },
      {
        "account": "Neon",
        "date": "2020-06-29T22:04:43.5727084",
        "amount": 3215
      },
      {
        "account": "Neon",
        "date": "2020-06-29T22:12:56.1067172",
        "amount": 5684
      },
      {
        "account": "Neon",
        "date": "2020-06-29T22:16:27.2445513",
        "amount": 651
      },
      {
        "account": "Neon",
        "date": "2020-06-29T22:21:20.1824672",
        "amount": 156
      },
      {
        "account": "Neon",
        "date": "2020-06-29T22:21:44.1658131",
        "amount": 123
      },
      {
        "account": "Neon",
        "date": "2020-06-29T22:27:36.0220252",
        "amount": 456
      },
      {
        "account": "Neon",
        "date": "2020-06-29T22:28:48.0578436",
        "amount": 234
      },
      {
        "account": "Neon",
        "date": "2020-07-01T21:07:13.8977384",
        "amount": 156
      },
      {
        "account": "Neon",
        "date": "2020-07-01T21:18:28.9606454",
        "amount": 156
      }
    ]
  },
  {
    "id": 38,
    "name": "Desjardins",
    "goal": 5000,
    "accountType": 0,
    "comments": "Cofomo account",
    "userId": 73,
    "records": [
      {
        "account": "Desjardins",
        "date": "2020-06-29T21:02:34.0731409",
        "amount": 987
      },
      {
        "account": "Desjardins",
        "date": "2020-06-29T21:07:46.9240505",
        "amount": 646
      },
      {
        "account": "Desjardins",
        "date": "2020-06-29T21:21:39.8843177",
        "amount": 987
      },
      {
        "account": "Desjardins",
        "date": "2020-06-29T22:02:03.4778858",
        "amount": 3321
      },
      {
        "account": "Desjardins",
        "date": "2020-06-29T22:04:43.5726176",
        "amount": 9568
      },
      {
        "account": "Desjardins",
        "date": "2020-06-29T22:12:56.1322664",
        "amount": 987
      },
      {
        "account": "Desjardins",
        "date": "2020-06-29T22:16:27.8556575",
        "amount": 123
      },
      {
        "account": "Desjardins",
        "date": "2020-06-29T22:21:20.1825914",
        "amount": 321
      },
      {
        "account": "Desjardins",
        "date": "2020-06-29T22:21:44.1652183",
        "amount": 3123
      },
      {
        "account": "Desjardins",
        "date": "2020-06-29T22:27:36.0197214",
        "amount": 987
      },
      {
        "account": "Desjardins",
        "date": "2020-06-29T22:28:47.7018019",
        "amount": 234
      },
      {
        "account": "Desjardins",
        "date": "2020-07-01T21:07:13.8998383",
        "amount": 897
      },
      {
        "account": "Desjardins",
        "date": "2020-07-01T21:18:31.4994734",
        "amount": 987
      },
      {
        "account": "Desjardins",
        "date": "2020-07-20T23:25:32.1465388",
        "amount": 3000
      }
    ]
  }
];
*/

export var completeAccountsForTest = [
  {
    id: 1,
    name: 'RBC Royal Bank',
    type: 'Income',
    comments: 'RBC Royal Bank',
    goal: 9000,
    series: [
      {
        id: 1,
        name: '04/12/2017',
        value: 2650
      },
      {
        id: 2,
        name: '02/01/2018',
        value: 4800
      },
      {
        id: 3,
        name: '04/01/2018',
        value: 9000
      }
    ]
  },
  {
    id: 2,
    name: 'Bank of Montreal',
    type: 'Income',
    comments: 'Bank of Montreal',
    goal: 5000,
    series: [
      {
        id: 1,
        name: '04/12/2017',
        value: 2500
      },
      {
        id: 2,
        name: '02/01/2018',
        value: 3100
      },
      {
        id: 3,
        name: '04/01/2018',
        value: 350
      }
    ]
  },
  {
    id: 3,
    name: 'National Bank of Canada',
    type: 'Income/Expense',
    comments: 'National Bank of Canada',
    goal: 7000,
    series: [
      {
        id: 1,
        name: '04/12/2017',
        value: 2500
      },
      {
        id: 2,
        name: '02/01/2018',
        value: 3100
      },
      {
        id: 3,
        name: '04/01/2018',
        value: 350
      }
    ]
  },
  {
    id: 4,
    name: 'Desjardins',
    type: 'Income/Expense',
    comments: 'Desjardins',
    goal: 8000,
    series: [
      {
        id: 1,
        name: '04/12/2017',
        value: 2500
      },
      {
        id: 2,
        name: '02/01/2018',
        value: 3100
      },
      {
        id: 3,
        name: '04/01/2018',
        value: 350
      }
    ]
  },
  {
    id: 5,
    name: 'HSBC',
    type: 'Income/Expense',
    comments: 'HSBC ',
    goal: 2000,
    series: [
      {
        id: 1,
        name: '04/12/2017',
        value: 2500
      },
      {
        id: 2,
        name: '02/01/2018',
        value: 3100
      },
      {
        id: 3,
        name: '04/01/2018',
        value: 350
      }
    ]
  },
  {
    id: 6,
    name: 'Canadian Western Bank',
    type: 'Income/Expense',
    comments: 'Canadian Western Bank',
    goal: 300,
    series: [
      {
        id: 1,
        name: '04/12/2017',
        value: 2500
      },
      {
        id: 2,
        name: '02/01/2018',
        value: 3100
      },
      {
        id: 3,
        name: '04/01/2018',
        value: 350
      }
    ]
  }
];

export var single = [
  {
    "name": "RBC Royal Bank",
    "value": 8940000
  },
  {
    "name": "Bank of Montreal",
    "value": 5000000
  },
  {
    "name": "National Bank of Canada",
    "value": 7200000
  },
  {
    "name": "Desjardins",
    "value": 5210000
  },
  {
    "name": "HSBC",
    "value": 9315000
  }
];

export var multi = [
  {
    "name": "RBC Royal Bank",
    "series": [
      {
        "name": "2010",
        "value": 7300000
      },
      {
        "name": "2011",
        "value": 8940000
      }
    ]
  },

  {
    "name": "Bank of Montreal",
    "series": [
      {
        "name": "2010",
        "value": 7870000
      },
      {
        "name": "2011",
        "value": 8270000
      }
    ]
  },

  {
    "name": "NBC",
    "series": [
      {
        "name": "2010",
        "value": 5000002
      },
      {
        "name": "2011",
        "value": 5800000
      }
    ]
  }
];
