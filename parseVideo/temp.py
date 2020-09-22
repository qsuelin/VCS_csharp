def check_include(list1, list2):
    i = 0
    while i <= len(l2) - len(l1):
        j = 0
        while j < len(l1):
            if l2[i] == l1[j]:
                i += 1
                j += 1
                if j == len(l1):
                    return True
            else:
                break;
        i += 1

    return False


l1 = [3, 4, 2]
l2 = [8, 2, 5, 3, 4, 2, 3]
print(check_include(l1, l2))

