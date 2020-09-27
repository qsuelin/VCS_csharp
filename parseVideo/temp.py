import os


def find_longest_subarr(arr):
    if len(arr) <= 1:
        return len(arr)
    else:
        # initiate current_subarr_len, max_subarr_len, ex_diff.
        cur_subarr_len = 1
        max_subarr_len = 1
        ex = {arr[0]}

        i = 1
        j = 0
        while i < len(arr):
            # iterate arr, compare to previous item.
            # if diff == 0, len++
            cur_diff = arr[i] - arr[i - 1]
            if cur_diff == 0:
                cur_subarr_len += 1
                print("1:", i, cur_subarr_len)
            # if diff = 1/-1, check ex_diff;
            elif abs(cur_diff) == 1 and len(ex) == 1:
                # if only one item in diff, ex_diff++, len++, update j
                j = i
                ex.add(arr[i])
                cur_subarr_len += 1
                print("2:", i, ex, cur_subarr_len)
            # if diff = 1/-1 && item in ex_diff, len++, update j
            elif abs(cur_diff) == 1 and arr[i] in ex:
                j = i
                cur_subarr_len += 1
                print('3:', i, cur_subarr_len)
            # if diff = 1/-1 && exceeds ex_diff, assign max_len, reset cur_subarr_len, ex_diff
            elif abs(cur_diff) == 1 and not arr[i] in ex:
                max_subarr_len = max(max_subarr_len, cur_subarr_len)
                cur_subarr_len = i - j + 1
                ex = {arr[i], arr[i-1]}
                print('4:', i, ex, cur_subarr_len)
            # if abs(diff) > 1, assign max_len, reset cur_subarr_len, ex_diff
            else:
                max_subarr_len = max(max_subarr_len, cur_subarr_len)
                cur_subarr_len = 1
                ex = {arr[i]}
                print("5:", i, ex, cur_subarr_len)

            i += 1

        return max(max_subarr_len, cur_subarr_len)


if __name__ == '__main__':
    print(find_longest_subarr([1, 2, 3, 3, 2, 3]))
