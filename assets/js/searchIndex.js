
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"FluentMigratorRunner",
            content:"FluentMigratorRunner",
            description:'',
            tags:''
        },
        {
            url:'/Cake.FluentMigrator/api/Cake.FluentMigrator/FluentMigratorRunner',
            title:"FluentMigratorRunner",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"FluentMigratorSettings",
            content:"FluentMigratorSettings",
            description:'',
            tags:''
        },
        {
            url:'/Cake.FluentMigrator/api/Cake.FluentMigrator/FluentMigratorSettings',
            title:"FluentMigratorSettings",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"FluentMigratorAliases",
            content:"FluentMigratorAliases",
            description:'',
            tags:''
        },
        {
            url:'/Cake.FluentMigrator/api/Cake.FluentMigrator/FluentMigratorAliases',
            title:"FluentMigratorAliases",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"FluentMigratorToolResolver",
            content:"FluentMigratorToolResolver",
            description:'',
            tags:''
        },
        {
            url:'/Cake.FluentMigrator/api/Cake.FluentMigrator/FluentMigratorToolResolver',
            title:"FluentMigratorToolResolver",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"IFluentMigratorToolResolver",
            content:"IFluentMigratorToolResolver",
            description:'',
            tags:''
        },
        {
            url:'/Cake.FluentMigrator/api/Cake.FluentMigrator/IFluentMigratorToolResolver',
            title:"IFluentMigratorToolResolver",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
