﻿

namespace Day_04_Puzzle_01
{
    internal static class Program
    {
        private static readonly (string CardInfo, string UserNumbers)[] TestData = new (string CardInfo, string UserNumbers)[]
        {
            new("Card 1: 41 48 83 86 17 ", "83 86  6 31 17  9 48 53"),
            new("Card 2: 13 32 20 16 61 ", "61 30 68 82 17 32 24 19"),
            new("Card 3:  1 21 53 59 44 ", "69 82 63 72 16 21 14  1"),
            new("Card 4: 41 92 73 84 69 ", "59 84 76 51 58  5 54 83"),
            new("Card 5: 87 83 26 28 32 ", "88 30 70 12 93 22 82 36"),
            new("Card 6: 31 18 13 56 72 ", "74 77 10 23 35 67 36 11"),
        };
        private static readonly (string CardInfo, string UserNumbers)[] FinalData = new (string CardInfo, string UserNumbers)[]
        {
            new ("Card   1: 58 68  1 21 88 37 66 61 23 25 ", "63 95 45 43 79 64 29 87  8 70 84 34 91 67  3 76 27 24 28 62 13 54 19 93  7"),
            new ("Card   2:  4 60 28  7 83 59 90 67 95 87 ", "7 67 77 13 11 19 54  3 95 25  1 87  4 80 64 60  8 94 53 90 59 83 31 70 28"),
            new ("Card   3: 88 52 39 57 13 85 87  9 61 40 ", "90  1  5  9 43 61 10 12 98 40 97 44 11  6 57 80 30 85 41 52 13 88 39 87 93"),
            new ("Card   4: 24 64 90 79  2 83 62 77 22 25 ", "64 83 37 36 42 79 24 78  5 76 41 71 43 99 62 93 57 55 90 18 73 22 92 25  2"),
            new ("Card   5: 25 65 86 11 26 40 27  9 61 51 ", "54 10 23 32 97 59 55 31  7 49 79 63 98  1 18 29 42 66 38 74 46 88 20  6 39"),
            new ("Card   6: 17 70 23 48  8 41 51  1 13 36 ", "70 42 13 53 89 59 18 36  6 26 17 31  9 51 15 63  2  1 41 48 10 34 33 55 44"),
            new ("Card   7: 51 64 21 49 30 93 60  4 10 44 ", "78 40 24  6  4 51 60 52 65 21 74  2 31 80 13 75 16 10 56 44 33  3 19 55 93"),
            new ("Card   8: 67 95 26 91 83 69  2 77 37 70 ", "58 64 83 41 69 63 11 30 73 28 75 87 76 15  6  2 10 51 20 47 82 48 61 46 53"),
            new ("Card   9: 21 26 37 87 88 98 50 34 43 39 ", "29 77 18 78 36 92  5  7 93 62 37 74 63 10  3 23 66 45 12  8 46  2 81 75 69"),
            new ("Card  10: 30 26 86 52 11 13 57 14 41 19 ", "13 52 19 24 86 26 83 30 22 68 62 85 98 99 14 41 18 27  8 70 23 11 38 76 77"),
            new ("Card  11: 58 31 80 77 57 26 76 49 48 67 ", "27 78 56 43  5 87 44 32 20 86 81 34 17 83 59  9 52 73 75 72 36 21 14 29 39"),
            new ("Card  12: 40 39 76 89 62 36 10 81 35 46 ", "9 83 20 58 52 14  1 25 27 10 60 39 47 72 86 12 80 88  8 56 87 64 65 28 16"),
            new ("Card  13: 39 95 10 34 15 42 26 70 67 32 ", "11 78 96 97 66 16 31 99 49 51 30 54 24 45 59 91 88  4 52 85 58 90 41 87 84"),
            new ("Card  14: 76 21 73 18 89 11 39 57 55 95 ", "54 23 62 85 17 36 70 50 30 63 81 79 12  2 40 93 41 37 27 56 84  1 68 66 86"),
            new ("Card  15: 35 40 13 30 75 31 21 58 66 95 ", "41 89 99 21 27 18  1 70 10 12 95 23 61 35 40 98 24 42 64 81 78 11 26 28 96"),
            new ("Card  16: 92  3 14 52 37 18 63 71 49 57 ", "36 60 45 12 59 73 89 40 70 78 68 95 19 27 86 39  4 67 23 91 11 84 72 21 14"),
            new ("Card  17: 29 13 22 95 64 12 83 75  7 54 ", "55 87 21 99 52 11 86 69 13 27 47 24 26 48 14 74 45 59  5 68 62 31 63 88 90"),
            new ("Card  18: 28 52 13 85 21 16 34 20 73 27 ", "17 50 10 82 62 71 45 28 18 60 88 19 11  1 25 27 67 54  4 35 68 39 36 20 87"),
            new ("Card  19: 92 24 77 63  8 49 22 68 51 38 ", "53 18 46 13 23 17 76 31 98 54 45  6 39  7 41 10 55 72 20 66 90 60 30 21 71"),
            new ("Card  20: 21 27  1 39 12 99 64 68 74 82 ", "67 72 16 80 23 97 75 36 57  8 90 40 14 71 93 65 18 51  4 79 17 55 48 49 10"),
            new ("Card  21: 13 62 64 60 23 58 27 83 31 59 ", "74 38  6  3 57 16 89 50  2 82 44 17 76 56 81 79 15 53 47 21 86 68 34 73 84"),
            new ("Card  22: 91 58 48 40 61 27 51 38 65 37 ", "38 46  5 60 93 61 51 72 48 45 64 37 71  2 27 20 56 17 40 66 58 57 86 91 65"),
            new ("Card  23: 49 98 13  3 61 66 16 46 22 44 ", "58 26 35 75 96 64 18  9 92 45 94 67 49 89 84 20 48 39 43 38 55 90  6 69 30"),
            new ("Card  24: 34 17 23 28 60 33 82 18  8  7 ", "52 68 73 88 94 77  6 55 87 79 63 84 74  4 70 18 38 60 82 31 51 58 89 36 61"),
            new ("Card  25: 71 88 43 21  2 35  4 61 29 70 ", "75 11 15 19 54 17 28 69 62 37 56 99 10 41 39 73 66 47 45 30 93 16 33  8 76"),
            new ("Card  26: 18  1 31 56 69 16 12 52 23 14 ", "26 60 62 12  7  2 69 78  3 57 73 25 52  1 61 27 16 56 53 47 14 44 90 54 55"),
            new ("Card  27: 14 38 31 88 77 23 80 69 15 66 ", "52 98 21 29 75 77 14 91 93 16  5 90 19 69 74 11  7 59 58 54  2 38 23 39 15"),
            new ("Card  28: 33 79 13 31 76 36 43 80 15 87 ", "83 73 34 62 22 58 13 87 72 36 78 39 80 93 45 43 31 59  1 40 76 15 74 48  4"),
            new ("Card  29: 74 29 34 52 51 87 40 53 31 91 ", "72 68 20 84 34 15 74 50  1 80 66  9 73 30 65 58 83 40 92 91 59 87 64 31 52"),
            new ("Card  30: 57 90 83 48 36 46 60 41  7 80 ", "18 11 81 15 36 10 52 59  9 44 92 21 37 83 89 61 94 12 13 60 69 68 28  5 16"),
            new ("Card  31: 48  8 60 22 99 96 31 51 80 46 ", "7 48  9 25 55 60 67 41  5 93  1 32 45 85 43 47 12 88 87 98 75 73 31 72 56"),
            new ("Card  32: 34 49 54 28  1 98 39 57 55 30 ", "28 92 99 36 52 12 14 58 98 65 90 22 39 94 49 19 53 82 41 79 56 26 29  5 27"),
            new ("Card  33: 48 42 54 81 80 52 91 64 23 45 ", "32 62 56 67  1  6 90 76 40 69 64 94  2 15 33 46 34 25  8 99 18 88 66  7 26"),
            new ("Card  34: 88 26 34 35 32 83 21 12 65 50 ", "75 52 45 44 69 59 86 66 37 29  6 54 98 55 40  9 85 89 39 71 90 51 77 82 38"),
            new ("Card  35: 39 93 90 75 58 49 19 24 51 52 ", "88 25 53 34 13 16 83 74 18 57 20 64 85 75  1 40 38  8  3 71 81 67 27 48 15"),
            new ("Card  36:  7 10 51 22 54 64 15  3 89 91 ", "73 97 20 60 29 31 45 88 70 49 17 94 38 47 53 12 96 55 39 87 26 57 48 85 65"),
            new ("Card  37: 90 23 83 61  6 42  7 98 13 20 ", "72 61 30 75 49 43 31 87 98 60 29 46 20  7 24  6 21 58 15 11 23 52 90 13 83"),
            new ("Card  38: 35 90 14 45 27 74 26 21 95 69 ", "6 49 89  1 56 23 68 48 69 38 16 75 39 37 51 91 78 77 28 17  9 62  4 80  5"),
            new ("Card  39: 65 11 79 74 26  9 36 29 85 27 ", "50 81 72  9  2 33 58 51 85 65 57 70 26 84 74 12  5 29 11 27 59 79 10 36 46"),
            new ("Card  40: 23 55 12 93 83 51  3 76 81 92 ", "33 12 42 44 25 82 91 10 80 38 83 16  5 26 34 86 22 31 21 39 19 55 62  7 88"),
            new ("Card  41: 92  3 30 98 74 27 26 86 13 85 ", "65 89 24 26 27 57 70 88 79 54 15 83 18  7 95  3 31 66 30 62 36 85 58 61 97"),
            new ("Card  42: 16 58 48 14 65  2 23 43  5  8 ", "51 98 31 40 77 74 83 15 45 59 17 32 43 72 70 10 57 47 28 64 26 82 75 14 19"),
            new ("Card  43: 55 49 28 94  4 42 14 52 78 81 ", "83 78 59 90 55 10 69 72 36 19 49 22 39 14 81 99 65 67 37 28 66 53  5 51 80"),
            new ("Card  44: 82 37 30 40 36  7 32 71 25 66 ", "56 75 86 55 95 25 84 26 47 38 79 98 83  9 17  6 68 40 10 91 96 11 31 61 90"),
            new ("Card  45: 45  9 61 48 42 82 97 89 99 44 ", "67 81 30 43 68  5  3 44 94 29 93 73 19 96 18 62 60 53 95 88 10 22 33 83 28"),
            new ("Card  46: 67 69 28 84  3 63 36 24 64 49 ", "2 10 81 77 20  8  9 14 39 35 96  4 87 16 68 82 65 42 92 97 58 37 45 38 55"),
            new ("Card  47: 38 69 31 67 61 86 65 35 66 89 ", "65 67 22 59 60 37 25 61 26 89 11 88 42  1 36 99 13 53 34 98 32 49 50 63 14"),
            new ("Card  48:  9 18 95 17 51 24 22 65 37 34 ", "86 20  5 21 82 64 70 29 25 80 59 90 94 66 60 93 75 12 95 43 97 23 47 22 73"),
            new ("Card  49: 87 88 30 25 68 40 52 43 48  5 ", "98 95  9 15 13 18 84 59 71 99 49 21 30 89 55  8 16 57 20 94  1 74 70 87 78"),
            new ("Card  50: 21 42 66 50  7 77 88 90 40 36 ", "52 55 99 45 67 15 41 38 72 79 53 20 91 73 75 25  1 22 44 48 36 33 63 97 94"),
            new ("Card  51: 86  9 90 51 98 24  4 60 11 62 ", "29 67 40 70  3 45 38 58 96 33 93 42 44  5 57 85 94 19 56 54 53 68  2 30 78"),
            new ("Card  52: 38 35 46 24 56 48 62 79 64 73 ", "88 97 64 48 90 38  5  6 17 24 62 72 44 83 78 35 96 14 73 11 79 55 56 46 93"),
            new ("Card  53: 17 29 59 50 80 21 67 97 53 27 ", "53 28 27 17  8 92 48 69 11 73 70 20 67 93 80 75 94 34 90 44 78 77 50 96 97"),
            new ("Card  54: 36 11 67 66 22 86 99 52 37 84 ", "86  1 97 63 82 96 45 32 70 15 34 80 17 28 20 56 94 78 35 24 59 48 13 95 55"),
            new ("Card  55: 91 70 23 37 18 97 24 14 77 61 ", "46 74 67 18 25 77 60 59 70 24  4 44 61 23 31 91 55 76 40 14 81  9 97 37 45"),
            new ("Card  56: 84 36 95 62 29 52 12  7 91 26 ", "29 89 24  7 23 49 84 25 36 95 72 12 65 75 52 90 62 37  8 60 38 91 76 26 16"),
            new ("Card  57: 51 59 19 45 15 57 73 18 95 56 ", "76 60 43 52 15 69 53 20 59 57 72  9 51 46 14 64 73 37 56 35 95 19 18 42 45"),
            new ("Card  58: 42 22 49 26 32 28 44 80 15 23 ", "39 95 20 68 97 37 22  7 71 51 28 24 15 58 26 34 11 43 18  6 44 31 98 48 81"),
            new ("Card  59: 54 57 37 58 46 63 74  8 64  9 ", "69 23 53 67 26 10 80 79 93 17 35 41 65 90  5 38 66 29  2 42 43 97 13 99 28"),
            new ("Card  60: 44  5 38 90 10 29 40 36 92 39 ", "97 41  7 91 25 43 30 10 89  3 54  5 13 11 96 61 36 55 86  1 57 90 74 38 46"),
            new ("Card  61: 43 66 70 36 39 16 67 35 32 94 ", "16 54 90 35 70 84 57 80 29 92 81 13 40 12 88 94 36 11 41 14 67 53 27 66 32"),
            new ("Card  62: 18  9  3 71 40 48 20 99 50 88 ", "73 61 19 25 96 44 51 46 39 27 55 28 24 33 93 14 95 70 12 41 10 18 88 86 60"),
            new ("Card  63: 16 61 27 91 80 34  2 32  1 10 ", "73 25 78 42 94  1 12 76 80 82 16 86 38 91 52 55 90 77 99 70 30 19 32 37 56"),
            new ("Card  64: 21 68 13 22 66  8 89 50 70 32 ", "46 22 32 15 70 50 80 89 87 45 68 13 79 44 21 66 90 55 28 11 31 36  4 24  8"),
            new ("Card  65: 95 84 36 24  5 96 63 83 12 33 ", "93 22 41 72 30 14  4 39 69 47 34 51 52 65 80 60 42 23  1 86 31 79 43 96 45"),
            new ("Card  66: 49 28 20 18 55 69 72 23 25  2 ", "84 44 70 29 72 15 28 14 64  5 46 16 33 93  9 43 42 45 65 86 90 67 47 40 58"),
            new ("Card  67: 90 46 11 67 40 48 73 44 72 92 ", "26 67 79 27 30 48  8 57 35 42 18 40 22 20 43 98 23 84 73 38 80 11 24  3 97"),
            new ("Card  68: 83 42 25 20  2 16 51 72 37 14 ", "58 91 12 86 43 51 23 52 99 84 77 83 97 20 44 69 34 76 39 42 60  2 21  8 56"),
            new ("Card  69: 93 54 79 66 95 33 36 30 64 46 ", "10 29 93 95 33 31 53 28 57 22 30 59 79 27 51 71 50  3 62 78  5 92 60 54 55"),
            new ("Card  70: 44 71 60 47 65 72 45 97 38 32 ", "34 32 22 97 74 83 33 86 94 44  5 98 75 63 13 55 93 84 72 91 29 99 76 43 47"),
            new ("Card  71: 17 74 82 50 63 80 96 66  9 40 ", "88 68 83 21 89 27 47  4 18 77 65 11 24 30 56  8 52 43 12 57 85 15 13 19 86"),
            new ("Card  72: 58 73 45 25 50 28 35 23 17 53 ", "21 88 74 80 43 82  7  9 46 57 51 77 61 85 52 39 75  5 19 90 83 48  2  3 84"),
            new ("Card  73: 70 33 42 60 41 72 47 49 98  2 ", "66 63 51 39 36 21  5 29  7  8 96 81 86 99 48 19 67 78 17 91 24 84 30 47 12"),
            new ("Card  74: 68 50 89 25 56 97 13 42 61 83 ", "37 79 74  8 44 29 21 58 66 40 49 17 51 34 73  2 84 14 10  4 47 85 98 46 90"),
            new ("Card  75: 59 28 61  9 12 43 97 32 73  4 ", "77 80 81 79 60 66 22 45 75 95 53 27 19 82  7  1 74 67 11 29 93 24 88 85  5"),
            new ("Card  76: 47 40 82 79 27 84 66 80 20 25 ", "25 23 27 75 89 67 82  5 30 62 37 81 15 19 40 84 51 80 47 77 66 90 20 44 79"),
            new ("Card  77: 81 78 95 42  9 74 15 88 77 19 ", "5 96 75 33 56 27 12 19 77 22 44  9 99 30 18 88 42 79 78 45 15 98 81 74 95"),
            new ("Card  78:  4 54 60 59 57 12 23 47 27 16 ", "43 34 64 23 35 32 37 94 65 86 74 13 18 30 36 66 68 99 31 92 17 93 28  2 11"),
            new ("Card  79: 27 78 97 35 30 95 85 87 76  2 ", "84 95 76  2 97 30 87 64 37 27 18 44 93 91 79 35 85 40 41 53  3 78 48 88 67"),
            new ("Card  80: 70 95 13 98 35 73 17 63 93 59 ", "3 32  2 12 48 15 70 40 78 83 57 26 19 38 92 42 71 67 85 25 76  9 93 60 59"),
            new ("Card  81: 50 64 63 66 86 89  4 24 17 82 ", "66 82 17 52 35 90 64 63 79 30 40 95  4 50 75 98 99 89  8 83 81 21 24 86 46"),
            new ("Card  82: 59 15 68 21 71 72 29 78 82 89 ", "34 63 83 66 54 79 16 57 73 22 93 58 95 41 37 44 86  5 67 77 11  8 27 24 90"),
            new ("Card  83: 31 34 55 60 81 58 95 56 70 67 ", "67 70 17 31  7 81 63 56 58 34 66 47 74 10 95 97 64 94 24 88 55 13 92  1 60"),
            new ("Card  84: 41 91 61 25 13 49 15 19 90 72 ", "66  7 63  5 20 56 94 42 19 81 74 24 45 82 26 76 86 41 72 57 27 46 53 91 95"),
            new ("Card  85: 42 96 36 85 75 10 80 25 32 78 ", "24 80 99 34 78 85 75 44 32 57 97 74 40 25 36 96 48 91 53 10 29 81 50  2 42"),
            new ("Card  86: 46 74  7 45  3 99 96 15 94 92 ", "9 40 81 30  7 87 18  4 80 24 62 49 60 36 93 52 74 14 23 90 79 25  6 44  3"),
            new ("Card  87: 47 80 14 95 55 91 65 26  1 64 ", "18  8  5 29  3 92 35 62 52 43 41 24 14 40 93 50  4 97 98 59  6 69 77 86 46"),
            new ("Card  88: 16 43  7 37 89 52 38 33 65 88 ", "59 51 97 16 89 57 96 68 37 62 43 63 94 12 91 87 88 74 17 65 15 52 14  3 42"),
            new ("Card  89: 46 55 91 86 69 56 57 33 74 80 ", "2  6 50 88 62 99 13 14 57 58 69 55 78 80 12 85 72 91 26 33 93 29 96 76  3"),
            new ("Card  90: 99 69 83 87 91 27 20 21 42 45 ", "49 87 39 65 52 69 42 89  1 47 24 95 29 38 91 33 27  2 51 64 45 21 20 99 83"),
            new ("Card  91: 56 87 54 79 28  2 39 96 92  3 ", "60 74 33 97 45 20 77 68 64 58 61 26 29 71 44  1  5 34 81 62 55 54 43 75 57"),
            new ("Card  92: 90 37 51 88 73  1 87 33 38 54 ", "23 19 90  1 83 72 86 84 96 33 74 25 54 48 61 15 16 89 17 37 87 32 62 51 38"),
            new ("Card  93: 14 19  9 10 88 30 34 28 92 60 ", "45 75 35  8 31 37 61 59 76 63 22 34 14 85 24  4 62 60 77 79 74 19 50 17 33"),
            new ("Card  94: 39 44 82 65 12 60 75 18 59 14 ", "66 71 83 27 40 28 91 23 76 26 25 35 38 63  4  3 64 15 86 49 32 22 89  6 13"),
            new ("Card  95: 70 55 42 10 17 96  8 25 99 74 ", "67 97 34 95 98 52 44 63 39 53 21 73 45 54  8 24 75 18  1 11 10 25 88 51 93"),
            new ("Card  96: 81 61 72 29 10 62 82 43 38 98 ", "19 69 17 58 83 66 76 54 95 41 44 50 48 99 65 60 15 64 73 62 61 84 98 13 14"),
            new ("Card  97: 58 76 38 77 75 36 62 88 43 32 ", "19 27 87 30 97 89 68  5 99 17 86 32 34 11 40 20 10 69 48 15 75 13 77  4 91"),
            new ("Card  98: 90 65 75 72 26 49 89 13 82 44 ", "74 99  9 94 45 31 21 50 67 32 95 56 23  2  1 36 22 14 83 91 51 25 81 88 58"),
            new ("Card  99: 43 26  7  1 18 21 58 38 92 46 ", "89 14 29 77 73 71 15 33 96 95 84 65 44 49 11  9 42 19 57 75 39  2 56 83 32"),
            new ("Card 100: 12 30 88 14 37 34 89  7 94 90 ", "44 26 53 70 36 28 48 74 83 23 87 45 18 19 69 98 64 78 86  1 68 31 92 24 65"),
            new ("Card 101: 79 23 24 92 88 59 11 64 84 89 ", "51 23 34 73  7 89 41 68 92 37 64  3 26 44 87 91 95  1 55 59 62 11 43  9 22"),
            new ("Card 102: 91 50 89 29 58  4 15 76 70 62 ", "76 79 42 87 63 15  4 68 16 52 66 91  7 50 62 44 82 58 89 70  8 32 75 71 29"),
            new ("Card 103: 25 22 54 85 93 77 37 86 39 62 ", "36 17  8 73 79 97 55 15 11 38 94 51 61 62 65 21 46 35 20 53 77 81 93 64 57"),
            new ("Card 104: 56 86 13 35 92 11 22 16 46 20 ", "53 38 13 22 56 35 20 23 18 98 29 92 97 59 86 46 74 16 25 63 30 11 12  7 27"),
            new ("Card 105: 84 32 51 40 79 52 91 56 38 74 ", "70 56 14 36 61 45 82  9 95 20 97 27 63 44 65 28 49 15 60 12 81 22 39 46 31"),
            new ("Card 106: 42  3 75 14 72 32  1 41 66 40 ", "26 65  8 47 55 57 90 48 81 45 64 17 93 30 61 95 80 58 97 49 23 88 11 77 69"),
            new ("Card 107: 88 67 38 43 63 22 54 33 47 53 ", "88 53 42 45 41 43 54 67 71 66  1 28 93 69 22 14 11 33 46 63 38 47 95 89 13"),
            new ("Card 108: 73 74 78 39 76  8 17 50 30 70 ", "59 39  8 63 57 73 87 30 51 84 17  7 78 67  1 54  5 72 99 40 76 77 89 83 95"),
            new ("Card 109: 76 26 78 74 22 87 34 79 60 15 ", "24 80 91 79 66 98  2 92 13 76 84 34 15 68 17 60 27 54 32 78 74 41 89 22 61"),
            new ("Card 110: 56 18 35 89 98 23 30 22 53 92 ", "44 41 70  6 17  4 86 34 83 66 12 28 47 32 33 91 16 93  2 49 11 22 99 25 29"),
            new ("Card 111: 45 53 54 99 59 15 86 98 55 44 ", "5 95 54 12  9 32 26  2 89 93 74 44  3 46  7 57 17 75 53 22 51 58 24 10 41"),
            new ("Card 112: 26 37  4 57 84 50 70 94 66 10 ", "66 89  3 60 51 23 34 30 91 61 13 45 10 38 39 18 92 72 83 42  9 99 41  7 95"),
            new ("Card 113: 49 67 76 86 83 78 54 87 36 66 ", "57 15  9 64 39 54 33 77 55 40 44 30 16 53 12 58 18 11  7 70 76 32 82 73 42"),
            new ("Card 114: 66 38 20  8 31 29 43 62 85 19 ", "26 23 68 91 94 95 70  9 21 43  6 35  4  8 74 52 47 99  2 53 86 93 97 59 34"),
            new ("Card 115:  3 88 71 98 25 33 40 97 46 75 ", "72  1 22 13 49 95 59 31 96  9 54 40 65 94 53 56 67 79 89 63 52 75 57 90 10"),
            new ("Card 116: 63 39 94 15 72 47 20 23 34 99 ", "8  4 78 82 11 50 40 84 22 60 19 21 57 47 77 79 45 27 93 96 29 85  6 33 36"),
            new ("Card 117: 88  6 47 71 98 39 69 79 67 15 ", "28  9 24 53 26  2 49 64 61 32  7 54 33 68 87 37 36 50 83  5 52 90 48 51 43"),
            new ("Card 118: 22 21 33 59 49 93 84 60 17 45 ", "22 50 60 28 26 74 61  4  6 89 81 12 84 45 97 56  2 59 42 83 49 86  5 94 30"),
            new ("Card 119: 10 23 38 22 37 25 28 34 58 50 ", "79 93 14 34 27 37 65 47  1 41 84 23 78 13 28 10 99 25 12 58 50 61 51 22 38"),
            new ("Card 120: 58 68 13 39 51 84 55 99 10 14 ", "23 56  3 27 50 64 55 32 86 62 67 47 78 73 44 24 97 70 49 20 43 96 30 72  5"),
            new ("Card 121: 72 38 96 86  5 15 19 49  6 90 ", "34 93 49 37 21 58 86 94 15 59 38 82 28 72 33 96 51 95 99  6  2 47 24 74 69"),
            new ("Card 122: 30 29 36  6 65 46 28 19 13 50 ", "95  1 65 44 79  5 12 88 75 62 66 34  6 24 68 30 31 89 13 64 33 52 96 43  2"),
            new ("Card 123: 17 76 16 48 28 71 61 33 95 15 ", "76 83 48 58 17 33  3  9 16 67 57 71 15 65 97 53 46 28 45 56 61 95 77 13 92"),
            new ("Card 124: 16 18 93 95 51 52 84 85 53 78 ", "97 28 77 42 86 54 19 55  7 72 21 98 35 80 18 99 52 43 68 26 14 81 40 25 56"),
            new ("Card 125: 11  8 17  1 52 36 20  9  6 90 ", "20 15 37  9 46 48 42 47 13 60 56 86  6 73 65 81 40 89 62 12 78 43 85  8 11"),
            new ("Card 126: 95 38 48 62 77 93  5 10 37 66 ", "62 69 28 29 66 19 46  6 64 24 31 89 79 88 18 65  8 92 34 49  3 12 38 45 22"),
            new ("Card 127: 26 87 33 47 83  8 85 27 64 56 ", "2 76 79 64  5 34 33 28 48 25 56 31 73 83 40 18 85 47 11 20  8 19 55 27 63"),
            new ("Card 128: 94 37 29 41 38 42 27 32 51 67 ", "40 43 15 70 35 11 61 86 39 16 56 14 26 91 55 87 84 12 19 68 24 46 13 20 45"),
            new ("Card 129: 96 73 94 47 35 54 45 10 86 84 ", "67 38 52 91 45 20 69 46 14 22 23 15 58 54 94 35 99 72 84 18 82 86 73 36 90"),
            new ("Card 130:  4 70 46 51 53 32 48 67 44 93 ", "81 97 34 82 17 24 88 38 84 96 89 16 54 66 64 30 15 77 20 11 87 28  7 62 45"),
            new ("Card 131: 31 75 50  3 71 74 95 29 80 68 ", "53 52 56 26 22 66 61 41 51 49 68 69 73 98 47 10 48 64  6 87  1 11  3  7 59"),
            new ("Card 132: 74  9 97 68 59 75 47 20 27 18 ", "61 27 28 73 14 29 53 21 87 82 71  4 99  9 89 59 35  6  1 52 51 42 44 24 55"),
            new ("Card 133: 61 84 71 42 10 30 50 46 32 98 ", "65 41 24 91 61 40  3 16  6 22 69  9 43 64  5 85 63 34 17 15 58 51 74 38 35"),
            new ("Card 134: 71 28  6 37 77 19 40 74 41 32 ", "60 61  9 19 26 14 88 20 64 89 81 27 43 29 62 93  4 74 80 68 59 38 75 46 17"),
            new ("Card 135:  9 30 86 93 96 98 27 70 57 82 ", "32  3 66  5 84 95 35 42 69 55 91 15 34 61 65 90 83  4 59 39 80 43 72 63 99"),
            new ("Card 136: 86  3 66 30 89 50 34 52 49 24 ", "36 16 67 11 70 94 75 68 27 91 46 64 10 83 26 12 73  6 21 48  4 55 81 20 41"),
            new ("Card 137: 54 45 73 33 60 59 71 44 35 39 ", "74 10 96 33 61 31 90 51 39  8 14 69 54 12 30 44 35 64 60 45 17 59 71 94 73"),
            new ("Card 138: 41 69 63 16 54 59 92  8 25 73 ", "54  8 91 49 89 83 61 93  5 25 88 53  1 51 32 57 74 52 42 63 65 24 47 11 48"),
            new ("Card 139:  6 56 41 54 88 46 13 23 50 78 ", "95 88 41  5 45 86 13 76 55 43 39 50 81 83 54 36 78 84 34 10 98 40 56 11 19"),
            new ("Card 140: 31 84 87 40 22 74  8 38 71 58 ", "71 36 90 11 53 37 14 55 23 22 44 26 59 27 33 13 34 10 31 43 38 57 92  5 75"),
            new ("Card 141: 10 28 45 18 31 37 73 78 69 23 ", "69 28 84 93 36 47 24 44 73 23 16 14 18 32 45 66 60 22 78 77 37 12 85 57  8"),
            new ("Card 142: 20  2 96 28 58 69 13 14 51 95 ", "54 49 38 23 51 92 28  3 20 36 35 89 14  2 13 95 70 69 58 34 22 47 30 17 63"),
            new ("Card 143: 65 71 17 81 51 63 20 42 49 44 ", "24 54 73 86 40 96 35 98 77 90 84 18  3 64 21 49 60 91  7 11 19 59 39 51 52"),
            new ("Card 144: 36 19 16 13 28 91 98 78 50 80 ", "52  9 19 41 60 58  3 95 93 87 50  1 36 73 28 16 98 68 80 24 14  2 13 91 78"),
            new ("Card 145: 62 71 15 13 27 46 50 99 81 54 ", "88 69 71 20 99 54 64 61 42 36 49 27 13 12  9 19 50 46 15 81 84 62 47  4 94"),
            new ("Card 146: 27 99 95  7 17 12 44  8 93 79 ", "65 21  1 30 15 80 42 41 89 71 26 82  4 14 63 38 64 62 16 46  2 70 97 61 59"),
            new ("Card 147: 68 70 18 50 32 42 37 11 71  2 ", "98 30 93 72 64 42 15 10 81 37 18 43 76 58 39 32 92 68 50 19  2 31 60 74 63"),
            new ("Card 148: 44 12 19  2 66 13 67 31  6 88 ", "8 41 20 87 96 21 57 54 15 53  1 47 75 14 10 61 84 32 37 99 83 91  7 56  4"),
            new ("Card 149:  5 90 25 48  9 28 40 79  6 43 ", "67  2 17 42 97 66 79 10 76 82 26 90 68 77 70 78 55 59 31 41 73 94 40 34 20"),
            new ("Card 150:  4 75 17 52 94 69 92 56 31 76 ", "54 28  7 17 90 60 58 80 69 52 65 31  5 44 96 55 23 87 76 40 42  1 35 21 64"),
            new ("Card 151: 11 50  8 63  7 49 25 55 58 89 ", "58 10 71 40  5 74  7 65 37  1 11 93 47 85 20 14 55 80 25 82 76 89 63 36 30"),
            new ("Card 152: 89 94 53 65 64 93 20 39 27 81 ", "46 14 59 64 27 93 53  3  1 38 36 30 95 32 52 39 44 73 61 83 90 65 17 88 62"),
            new ("Card 153:  7 26 63 17 43 92 38 31 35 94 ", "81 43 60  6 17  7 57 31 45 92  9 62 20 63  8 50 88 15 54 59 22 86 44 85 79"),
            new ("Card 154: 48 78 69 23 81  8 89 45 33 83 ", "25 13 69 95 48 10 36 67 30 71 45 33 29 44  6 52 89 18 56 14 99 43 49 11 80"),
            new ("Card 155: 71 98 91 31  7 68 97 36 37  2 ", "64 28 57 99 98  2 35 67 75 39 52 26 81 92 16 43 59 17 78 30 36 12 87 62 31"),
            new ("Card 156: 77 59 92 24 15 19 39 67  5 89 ", "59 71 54 35 90 20 68 63 74 66 15 79 50 73  9 65 25 31 77 41 42 80 81  8 33"),
            new ("Card 157: 80 47 90 46 73 51 35 30 96 61 ", "56 88 79 98 86 70 65 64 62 53 31 42  7 24 29 82 15  9 40 14 52 83 84 93 69"),
            new ("Card 158: 73  2 19 15 29 78 96 30 33 85 ", "57 88 89 63 22 43  1 39 83 72 53 13 55 70  5  8 34 54 97 71 90 59 95 47 49"),
            new ("Card 159: 28 85 71 78 17 57 25 43 94 10 ", "1 64 70 49 41  7 60 32 84 21 72 98 34 47  2 91 45 82  8 87 27 35 92 33 97"),
            new ("Card 160:  1 12 51 35 59 92 16 33 80 70 ", "83 50 92 76 44 73 17 16 70 45 56 33 67  1 53 59 60 99 49 93 12 96 36 22 61"),
            new ("Card 161: 88  5 52  6 10 41 15 49 56 92 ", "5 48 88 95 57  6 29 69 56 41 70 11 64 77 71 15 28 49 51 10 93 78 92 52 50"),
            new ("Card 162: 49 23 69 10 61 93 35 70 97 29 ", "23 92 84 65 83  8  5 34 93 35 97 69 61  3 10 14 79 76 27 49 11 29 13 48 70"),
            new ("Card 163: 96  5 13 89 51 52  4 98 91 76 ", "89 54 84 90 44 91  4 76 39 52 13 47 98 51 35 96 79 80 25  1 14 60  5 43  9"),
            new ("Card 164: 18 68 21 51 33 69 92 65 94 20 ", "38 39 33 12 18 94 53 81 65 82 22 21 51  5 72 20 19  8 69 83 92 98 44 49 68"),
            new ("Card 165: 42 22 36 56 10 17 54 24 72 91 ", "72  3  2 10 42 64 54 61 24 91 97 50 36 33 49 65 60 78  9 22 56 17 94 37 67"),
            new ("Card 166: 53  4 58 59 62 86 25 88 71 51 ", "25 21 79 31 56 43 55 78 88  8 14 46 37 53 60 81 58 83 50 28 68 62  5 70 11"),
            new ("Card 167: 67 82 17 60 51 73 39 74  8 94 ", "42 21 94 73 67  9 89 12 51  4 59 25 60 83 17 98 39 86 31 82 74 27 50  8 93"),
            new ("Card 168: 65 84 50 76 48 23 88 60  9 31 ", "16  7 26 75 56 11 49 84 24  8 79 62 96  1 63 60  5 33  6 88 43 92 61 97 53"),
            new ("Card 169: 82 22 84  2 78 72 77 45 49 71 ", "16 70 63 77 22 61 40 51 64 84 97 42 14 18  2 74 47 52 19 75 65 96 33  6  1"),
            new ("Card 170: 75 58 29 51 93 22 12 99 41 18 ", "72 58 89 17 15  3 93  1 12 87 53 62 41 29 56 80 16 99 50  5 51 68 18 22 75"),
            new ("Card 171: 66 23  4  9 44 20 88 80 47 19 ", "9 42 82 19 50 20 97 66 35 31 44 79 99 28 93 47  8 51 58 77 14 88  4 52 27"),
            new ("Card 172: 35 43 91 71 93 57 10 49  7  1 ", "24  4 54  5 65 11  1 19 13 92 62 21 39 18 61  7 44 72 14 57 10  6 94 80 95"),
            new ("Card 173: 32 94 54 14 30 61 44 46 39  1 ", "47 61 94 78 33 12  1 30 35 57 44  7 14 54 68  4 39 32  9 46 42 62 71 60 63"),
            new ("Card 174: 86 76  1 19 90 50 54  9 59 18 ", "9 20 52 73 39 56 81 24 55 18 59 40  4 62 78 19 50 51 97 44 86 90 76  1 25"),
            new ("Card 175: 97 33 65 31 88 19 79  1 68 18 ", "40 12 66 46 68 39 59 70 28 79  1 97 31 65 22 55 42 81 19 33 74 57 83 48 88"),
            new ("Card 176: 46 28 57 91 67 49 22 41 48 10 ", "64 22 54 68 30  8 91 93 21 83 85 79 84 73 52 33 98 67 59 74 38 99 19 41 96"),
            new ("Card 177: 92 14 73  1 42 72 75 21 63 52 ", "5 90 54 70 44 42 55 99 96 85 35 62 26 74 57 17 68 45 36  9 93 15 43 48 83"),
            new ("Card 178: 13 91 79 17 33 49 87 73 39 45 ", "25 47 11 81 76 57 43 36 87 64 15 52 67  5 13 55 72 31  2 24 70 19 53 95 45"),
            new ("Card 179: 79 42 94 58 34 15  3 49 19 16 ", "75  3 60 56 20 64 67 21 76 15 92 47 29 50 62 41 80 10 31 52 23 90 53 96 58"),
            new ("Card 180: 57 92 69 87 99 12 78 23 89 43 ", "68 70  5 79  9 63 88 17 82 19 47 34 11 25 60 67 71 80  2 54 18 33 38 91 30"),
            new ("Card 181: 90 73 65 75 52 81 94 48 57 44 ", "35 45 97 84 49 77  5 36 30  4 55 69 21 26 31 19 76 68 66 80 53 72 40 52 54"),
            new ("Card 182: 59 86 35 48 42 87 52 51 90 62 ", "38 70 60 32 66 95 72 22 23 24 28 26 56 40 78  2 51 43 39 33 93 57 87  6 31"),
            new ("Card 183: 60 30 90 38 62  7 42 28 20 44 ", "85 88 91 11 73 81 54  7 18 66  8  6 79  4 29 31 68  5 16 52 94 34 57 70  2"),
            new ("Card 184:  2 32 36 29 90 89 16 10 46 94 ", "52 78 18 39 45 42 40 83 62 50 96  9 33 72 77 81 43 25 64 57 24 95 30 74 35"),
            new ("Card 185:  3 62 16 97 60  2 68 28 15 49 ", "9 42 62 39 28 61  8 73  2 16 71 52 97  3 49 38 68 15 12 27 60 30  7 96 70"),
            new ("Card 186: 82 18 77 36 31 41 38 83 48 24 ", "13 61 83 65 51 82 63 93 88 31 76 94 25 18 36 35  7 22 77 78 55 14 38 48 50"),
            new ("Card 187: 99 58 65 32 17 79 38 72 41 60 ", "99 44 86 60 79 53 56 32 38 19 64 45 34 98 14 20 58 68 17 97 13 72 41 65 77"),
            new ("Card 188: 20 75 76 72 91 98 19 45 74 60 ", "71 45 60 20 31 74 72 76 98 15 13 91 43 10 75 58 70 64 84 37 19 77 83 42 96"),
            new ("Card 189: 31 70 40 72  9 74 41 43  1 35 ", "6 28 27 35 23  9 13 74 45 38 90  3 22 19 46  8 98 94 43 79 15 24 56 32 73"),
            new ("Card 190: 55 61  7 69 21  5 36 25 41 26 ", "8 22 79 57  9 91 84 81 15 35 80 77 69 60 65  2 45 32 38 82 95 19  3 83 23"),
            new ("Card 191: 30 59 66  9 53 71 27 91 58 12 ", "59 45 42 92 58 66 61 55 18 80 94 63 21 40  3 75 29 11 88 81 79 28 30 41  9"),
            new ("Card 192: 63 62 44 26 38 79 68 74  5 14 ", "9 79 44 71 63 38 26 56 96 16  5 62 12 22 72 99 84 14 68 76  6 70 74 88 45"),
            new ("Card 193: 36 33 91 12 96 88 67 35 41 18 ", "68 41 91  1 25 63 19 69  4 58 85 13 77 12 26 35 49 20 18 55 60 67 96 64 88"),
            new ("Card 194: 76 61 87 12 15 24 48  6 77 66 ", "41 51  6  1 83 26  9 71 67 32 53 68 88 94 30 99 35 98 13 44  2 72  8 74 82"),
            new ("Card 195: 85  6 35  2 11 29 39 48 13 28 ", "21 10 81 28  5 43 58 36 31 39 50 19  2 40 59 20 86 90 96 53 23 70 85  8 68"),
            new ("Card 196: 47 94 65 85 17 71 48 60 19 21 ", "42 17 94 79 47 65 13 21 48 45 27 26 71 78 85 50 87  3 91  1 28 58 19 57  9"),
            new ("Card 197: 91 45 87 63 88  8 21 16  4 83 ", "51 86 95 45 15 77 60 85 58 47 22 67 17 54 79  8 61 82 57 64 99 70 93 88 14"),
            new ("Card 198: 32 29  5  2 68 99 66 48 23 10 ", "5 86 96 59 16 22 97 99 55 38 50 58 80 89 11 75 17 87 93 63 34 73 68 92 48"),
            new ("Card 199: 38 48 17 67 27 85 63 80 15 79 ", "78 84 17 52 51 41 48 80 94 12 82 98  4 21 57 15 85 62 63 93 56 55 18 13 83"),
            new ("Card 200: 47 65 31 18 49 45 73 50 66 37 ", "3  7 50 65 44 97 94 92 19 54  5 71  8 15 38 89  9 59 49 78 98 18 55 60 25"),
            new ("Card 201: 51  6 38 45 20 98 19 49 42 46 ", "39 84 30 18 26 82 76 34 53 66 99 92 14 32 43 91 71 28 86 83 36 87  4 73 90"),
            new ("Card 202: 36 39  6 87 46 59 38 94 77 81 ", "29 67  6 95 96 43 22 91 64 79 72 76 69 42 56 18  5 92 31 48 49 57 59 70 47"),
            new ("Card 203: 65 94 83 37 74 48 82 58 24 32 ", "15 84 41 50 44 36 45 34 52 48 40 92 88 33 24 82 80 18 78 53 66 49 13 98 89"),
            new ("Card 204: 20 50 78 99 25 67 80 86 54 47 ", "62 64 51 14 83 79 61 37  4 98 16 85 27 10 70 50 13  8 53 63 65 97 71 21 94"),
            new ("Card 205: 85 47  9 91 79 52 28 26 19 33 ", "61 75 46 17 16 34 98  3 62 56 74 54 88 99  2 57  4 78 32 72 97 81 90 64 63"),
            new ("Card 206: 80 39 46 82 49 98 73 32 85 15 ", "90 60 47 54 59 41 20 33 92 11 88 61 99 84 94 78 71 35 55  2 51 40 67 18 66"),
        };
        private static int _runningTotal;

        static void Main(string[] args)
        {
            //(string CardInfo, string UserNumbers)[] scratcherRounds = TestData;
            (string CardInfo, string UserNumbers)[] scratcherRounds = FinalData;

            foreach ((string CardInfo, string UserNumbers) scratcher in scratcherRounds)
            {
                _runningTotal += CheckCardScore(scratcher);
            }

            Console.WriteLine(_runningTotal);
            Console.ReadLine();
        }

        private static int CheckCardScore((string CardInfo, string UserNumbers) scratcher)
        {
            int score = 0;

            int[] sortedCardNumbers = GetCardNumbers(scratcher.CardInfo, true);
            int[] playerNumbers = GetCardNumbers(scratcher.UserNumbers, false);
            foreach (int cardNumber in playerNumbers)
            {
                if (sortedCardNumbers.Contains(cardNumber))
                {
                    if (score == 0)
                    {
                        score++;
                    }
                    else
                    {
                        score *= 2;
                    }
                }
            }

            return score;
        }

        private static int[] GetCardNumbers(string sourceString, bool sort)
        {
            string[] cardInfo = sourceString.Split(':');
            string[] numberStrings = cardInfo[cardInfo.Length == 1 ? 0 : 1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<int> numbers = new List<int>();

            for (int i = 0; i < numberStrings.Length; i++)
            {
                numbers.Add(int.Parse(numberStrings[i]));
            }

            if (sort)
            {
                numbers.Sort();
            }

            return numbers.ToArray();
        }
    }
}
