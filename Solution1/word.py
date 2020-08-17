
class StrComparer:
    def __countLetters(self, str):
        dic = {}
        for l in str.lower():
            if l in dic:
                dic[l] += 1
            else:
                dic[l] = 1
        return dic

    def __calculate(self, source, target):
        result = True
        for item in source.items():
            lookup = item[0]
            if lookup not in target:
                result = False
                break
            if target[lookup] < item[1]:
                result = False
                break
        return result

    def compare(self,str1, str2):
        dic1 = self.__countLetters(str1)
        dic2 = self.__countLetters(str2)

        source, target = {}, {}
        if len(dic1) <= len(dic2):
            source = dic1
            target = dic2
        else:
            source = dic2
            target = dic1

        return self.__calculate(source, target)

str1 = "baba"
str2 = "abab"
result = StrComparer().compare(str1, str2)
print(result)
