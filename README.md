# Urban Dictionary Spell Checker
Don't accidentally [diss](http://diss.urbanup.com/37489) someone, [brah](http://brah.urbanup.com/1485311)!

## Prerequisites
* .NET Core 6
* _MongoDB_

## Getting started
* build and run solution:

```bash
$ dotnet run
```

* open [SwaggerUI](http://localhost:5287/swagger/index.html)
* enter text and see what fax pas you've made!

## Urban Dictionary Data
[Unofficial Urban Dictionary API](https://dev.to/nhighleysalongenius/comment/epgk)

```text
but I wouldn't count on your app surviving for long if they see you slurping traffic.
```
<details>

### Getting data
* https://www.reddit.com/r/datasets/comments/63spoc/19gb_of_urban_dictionary_definitions_1999_may_2016/
* https://archive.org/details/UrbanDictionary1999-May2016DefinitionsCorpus
  * UT_raw_plus_lowercase.7z
    * `words.json`

### Loading data
* extract `words.json` from `UT_raw_plus_lowercase.7z`
* import into _MongoDB_

</details>
