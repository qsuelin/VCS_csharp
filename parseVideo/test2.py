def sort(arr):
    i = 0
    while i < len(arr):
        pre_arr = arr[:i]
        pre_arr = position(pre_arr, arr[i])
        i += 1
        arr = pre_arr + arr[i:]

    return arr


def position(arr, item):
    if len(arr) == 0:
        arr.append(item)
    else:
        i = 0
        while i < len(arr):
            if arr[i] < item:
                if i == len(arr) - 1:
                    arr.append(item)
                    break
                i += 1
                continue
            else:
                arr.insert(i, item)
                break

    return arr


if __name__ == '__main__':
    print(sort([3,2,2,4, 1,5,6,4]))