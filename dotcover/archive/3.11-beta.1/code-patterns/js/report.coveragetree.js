$(document).ready(function() {
    $("#treeDiv").dynatree({
        keyboard: true,
        imagePath: "code-patterns/images/",
        onPostInit: function(isReloading, isError) {
            var rootNode = $("#treeDiv").dynatree("getRoot");
            rootNode.data.childIds = [0];
            loadChildren(rootNode);
        },

        onCustomRender: function(node) {
            return createNodePresentation(node.data.title, node.data.percent, node.data.clickable);
        },

        onActivate: function(node) {
            // Use our custom attribute to load the new target content:
            if (node.data.url != "")
                $("#sourceViewer").attr("src", node.data.url);
            else
                $("#sourceViewer").attr("src", blankSource);
        },

        onLazyRead: function(node) {
            loadChildren(node);
            return true;
        }
    });
});

function loadChildren(node) {
    if (!node.data.childIds)
        return;

      $.each(node.data.childIds, function (i, childId) {
        executeWithNode(childId, function (data) {
          var hasChildren = data.c && data.c.length > 0;
          var sourceUrl = data.f ? (sourceReferencePrefix + data.f + ".html#src" + data.f + "." + (data.k ? "dccv" : "dcuc") + "." + data.y + "." + data.x) : "";
          var nodeTypeImageName = nodeTypeImageNames[data.i];
          node.addChild({ key: childId, title: data.n, percent: data.p, childIds: data.c, isLazy: hasChildren, isFolder: false, icon: nodeTypeImageName == "" ? false : nodeTypeImageName, url: sourceUrl, clickable: sourceUrl != "" });
        });
      });
}

function createNodePresentation(name, percent, clickable) {
    var renderedNode = percent == emptyPercentValue ? "" : "<img src='code-patterns/images/" + percent + ".png' class='percent-image'>";
    var clazz = clickable ? "clickable-coverage-node" : "coverage-node";
    renderedNode += "<a href='#' class='" + clazz + "'>" + name + "</a>";
    return renderedNode;
}

function executeWithNode(id, handler) {

  var blockIndex = div(id, blockSize);
  var block = coverageData[blockIndex];
  if (!block)
    return;

  var itemIndex = id % blockSize;
  var item = block[itemIndex];
  if (!item)
    return;
  
  handler(item);
}

function div(x, y) {
    var d = x / y;
    // since js has no integer division
    if(d >= 0)
      return Math.floor(d);
    else
      return Math.ceil(d);
}